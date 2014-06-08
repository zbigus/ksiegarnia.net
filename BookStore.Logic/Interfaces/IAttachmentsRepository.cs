using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IAttachmentsRepository
    {
        /// <summary>
        /// Pobiera załącznik z bazy
        /// </summary>
        /// <param name="id">Id załącznika</param>
        /// <returns>Model załącznika</returns>
        AttachmentModel GetAttachment(int id);

        /// <summary>
        /// Pobiera wszystkie załączniki z bazy
        /// </summary>
        /// <returns>Lista modeli załączników</returns>
        List<AttachmentModel> GetAttachments();
        
        /// <summary>
        /// Pobiera załączniki przypisane do konkretnej książki
        /// </summary>
        /// <param name="bookId">Id książki</param>
        /// <returns>Lista modeli załączników</returns>
        List<AttachmentModel> GetAttachments(int bookId);
        
        /// <summary>
        /// Dodaje załącznik do bazy jeżeli nie istniej i podana książka istnieje
        /// </summary>
        /// <param name="attachment">Model załącznika</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool AddAttachment(AttachmentModel attachment);
        
        /// <summary>
        /// Dodaje załączniki do bazy jeżeli nie istnieją i podana książka istnieje
        /// </summary>
        /// <param name="attachments">Kolekcja modeli załączników</param>
        void AddAttachments(IEnumerable<AttachmentModel> attachments);
        
        /// <summary>
        /// Usuwa załącznik z bazy jeżeli istniej
        /// </summary>
        /// <param name="id">Id załącznika</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool DeleteAttachment(int id);
        
        /// <summary>
        /// Usuwa załączniki z bazy jeżeli istnieją
        /// </summary>
        /// <param name="ids">Kolekcja id załaczników</param>
        void DeleteAttachments(IEnumerable<int> ids);
        
        /// <summary>
        /// Usuwa z bazy załączniki, które nie znajdują się w kolekcji i dodaje te które się w niej znajdują
        /// </summary>
        /// <param name="attachments">Kolekcja modeli załączników</param>
        void AddDeleteAttachments(IEnumerable<AttachmentModel> attachments);
        
        /// <summary>
        /// Usuwa wszystkie załączniki danej książki
        /// </summary>
        /// <param name="bookId">Id książki</param>
        void ClearAttachments(int bookId);
        
        /// <summary>
        /// Aktualizacja załącznika. Sprawdza czy załącznik istnieje
        /// </summary>
        /// <param name="attachment">Model załącznika</param>
        /// <returns>Potwierdzenie aktualizacji</returns>
        bool UpdateAttachment(AttachmentModel attachment);
        
        /// <summary>
        /// Sprawdzenie czy załącznik istnieje
        /// </summary>
        /// <param name="id">Id załącznika</param>
        /// <returns>Rezultat sprawdzenia</returns>
        bool AttachmentExists(int id);
    }
}