using Microsoft.EntityFrameworkCore;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Data;
using StudyPro.Services.Data.EF;

namespace StudyPro.Services.Data
{
    public class EFCardService :ICardService
    {
        private readonly StudyProDataContext _db;

        public EFCardService(StudyProDataContext db)
        {
            this._db = db;
        }
        public async Task<List<Card>> GetAllAsync()
        {
            return await _db.Cards.ToListAsync();
        }

        public async Task<Card> GetByIDAsync(int id)
        {
            return await _db.Cards.FindAsync(id);
        }

        public async Task<List<Card>> GetCardsByCategoryIDAsync(int categoryID)
        {
            var cards = await _db.Cards
                .Where(c => c.CategoryID == categoryID)
                .OrderBy(c => c.Level)
                .ToListAsync();
            return cards;
        }
        public async Task<Card> AddCardAsync(Card card)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
            return card;
        }

        public async Task DeleteCardAsync(int id)
        {
            var current = await GetByIDAsync(id);
            _db.Cards.Remove(current);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCardAsync(int id, Card card)
        {
            var current = await GetByIDAsync(id) ;
            //_db.Cards.Update(card);
            current.CardID = card.CardID;
            current.Term = card.Term;
            current.CategoryID = card.CategoryID;
            current.Level = card.Level;
            current.Definition = card.Definition;

            await _db.SaveChangesAsync();
        }

        public async Task AddImageToCardAsync(int id, string imagePath)
        {
            var current = await GetByIDAsync(id);      
            current.ImagePath = imagePath;

            await _db.SaveChangesAsync();
        }
    }
}
