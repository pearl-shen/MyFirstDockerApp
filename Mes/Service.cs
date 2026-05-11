using MyFirstApp.MesModel;

namespace MyFirstApp.Services
{
    public class MesService
    {
        // 這是「進站」的方法，現在它乖乖待在 class 裡面了
        public bool MoveIn(Lot lot, Equipment eq)
        {
            // 簡單的防呆邏輯
            if (lot.Status == LotStatus.Wait && eq.Status == EquipmentStatus.Idle)
            {
                lot.Status = LotStatus.Running;
                eq.Status = EquipmentStatus.Busy;
                lot.CurrentEquipmentId = eq.Id;
                return true;
            }
            
            return false;
        }
    }
}