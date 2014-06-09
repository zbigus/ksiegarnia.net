using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entities.Dal;
using BookStore.Entities.Models;
using BookStore.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStore.UnitTests.Repository
{
    [TestClass]
    public class AtachmentsRepositoryTest
    {
        private readonly Logic.Repository.Repository _repository;
        private readonly User _user;
        private readonly Book _book;

        public AtachmentsRepositoryTest()
        {
            var context = new BookStoreContext();
            _book = context.Books.First();
            _repository = new Logic.Repository.Repository();
        }

        [TestMethod]
        public void GetAllAttachments()
        {
            var result = _repository.GetAttachments();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetNonExistingAttachment()
        {
            var result = _repository.GetAttachment(0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetExistingAttachment()
        {
            var result = _repository.GetAttachment(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.GetType() == typeof(AttachmentModel));
        }

        [TestMethod]
        public void GetAttachmentsForNonexistingBook()
        {
            var result = _repository.GetAttachments(0);
            Assert.IsTrue(result.Count == 0);
            Assert.IsTrue(result.GetType() == typeof(List<AttachmentModel>));
        }

        [TestMethod]
        public void GetAttachmentsForExistingBook()
        {
            var result = _repository.GetAttachments(1);
            Assert.IsTrue(result.Count > 0);
            Assert.IsTrue(result.GetType() == typeof(List<AttachmentModel>));
        }

        [TestMethod]
        public void AddExistingAttachment()
        {
            var attachment = _repository.GetAttachments(1).First();
            var result = _repository.AddAttachment(attachment);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == false);
        }

        [TestMethod]
        public void AddAttachmentToNonexistingBook()
        {
            var attachment = _repository.GetAttachments(1).First();
            attachment.BookId = 0;
            var result = _repository.AddAttachment(attachment);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == false);
        }

    }
}
