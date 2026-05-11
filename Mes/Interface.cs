   using MyFirstApp.MesModel;
   public interface IMesService
    {
        bool MoveIn(Lot lot, Equipment equipment);
    }

    public class MesService : IMesService
    {
        public bool MoveIn(Lot lot, Equipment equipment)
        {
            if (equipment.Status != EquipmentStatus.Idle) return false;
            lot.Status = LotStatus.Running;
            lot.CurrentEquipmentId = equipment.Id;
            equipment.Status = EquipmentStatus.Busy;
            return true;
        }
    }