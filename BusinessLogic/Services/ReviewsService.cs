using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReviewsService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Review>> GetAll()
        {
            return await _repositoryWrapper.Review.FindAll();
        }

        public async Task<Review> GetById(int id)
        {
            var review = await _repositoryWrapper.Review
                .FindByCondition(x => x.ReviewId == id && x.IsDeleted == false);

            if (review is null || review.Count == 0)
            {
                throw new ArgumentNullException("Review not found");
            }

            return review.First();
        }

        public async Task Create(Review model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.Rating < 1 || model.Rating > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5");
            }

            model.CreatedAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Review.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Review model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingReview = await _repositoryWrapper.Review
                .FindByCondition(x => x.ReviewId == model.ReviewId && x.IsDeleted == false);

            if (existingReview is null || existingReview.Count == 0)
            {
                throw new ArgumentNullException("Review not found");
            }

            _repositoryWrapper.Review.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var review = await _repositoryWrapper.Review
                .FindByCondition(x => x.ReviewId == id && x.IsDeleted == false);

            if (review is null || review.Count == 0)
            {
                throw new ArgumentNullException("Review not found");
            }

            var reviewToDelete = review.First();
            reviewToDelete.IsDeleted = true;
            _repositoryWrapper.Review.Update(reviewToDelete);
            _repositoryWrapper.Save();
        }
    }
}