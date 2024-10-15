using Domain.Interfaces;
using Domain.Models;
using System;

namespace BusinessLogic.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public MessagesService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Message>> GetAll()
        {
            return await _repositoryWrapper.Message.FindByCondition(x => x.IsDeleted == false);
        }

        public async Task<Message> GetById(int id)
        {
            var message = await _repositoryWrapper.Message
                .FindByCondition(x => x.MessageId == id && x.IsDeleted == false);

            if (message is null || message.Count == 0)
            {
                throw new ArgumentNullException("Message not found");
            }

            return message.First();
        }

        public async Task Create(Message model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            model.SentAt = DateTime.Now;
            model.IsDeleted = false;

            await _repositoryWrapper.Message.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Message model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingMessage = await _repositoryWrapper.Message
                .FindByCondition(x => x.MessageId == model.MessageId && x.IsDeleted == false);

            if (existingMessage is null || existingMessage.Count == 0)
            {
                throw new ArgumentNullException("Message not found");
            }

            _repositoryWrapper.Message.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var message = await _repositoryWrapper.Message
                .FindByCondition(x => x.MessageId == id && x.IsDeleted == false);

            if (message is null || message.Count == 0)
            {
                throw new ArgumentNullException("Message not found");
            }

            var messageToDelete = message.First();
            messageToDelete.IsDeleted = true;

            _repositoryWrapper.Message.Update(messageToDelete);
            _repositoryWrapper.Save();
        }
    }
}
