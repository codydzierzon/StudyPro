using StudyPro.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPro.Models.Interfaces.Data
{
    public interface ICardService
    {
        Task<List<Card>> GetAllAsync();
        Task<Card> GetByIDAsync(int id);
        Task<List<Card>> GetCardsByCategoryIDAsync(int categoryID);
        Task<Card> AddCardAsync(Card card);
        Task DeleteCardAsync(int id);
        Task UpdateCardAsync(int id , Card card);
        Task AddImageToCardAsync(int id, string imagePath);

    }
}
