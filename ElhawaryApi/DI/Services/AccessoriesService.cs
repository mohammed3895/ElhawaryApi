
using Microsoft.EntityFrameworkCore;

namespace ElhawaryApi.DI.Services
{
    public class AccessoriesService(AppDbcontext context) : IAccessoriesService
    {
        private readonly AppDbcontext _context = context;

        public List<AccessoryDTO> GetAccessories()
        {
            var list = _context.Accessories.ToList();
            List<AccessoryDTO> accessories= [];

            try
            {
                foreach (var item in list)
                {
                    accessories.Add(new(
                        id: item.Id,
                        name: item.Name,
                        price: item.Price,
                        purchasePrice: item.PurchasePrice,
                        qantity: item.Qantity
                    ));
                }
                return accessories;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
