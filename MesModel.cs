//該檔案位置: MyFirstApp資料夾的MesModel
namespace MyFirstApp.MesModel
{
    // public: 公開的, enum: 列舉
    // 批次狀態：等待中、生產中、已完成
    public enum LotStatus { Wait, Running, Finished }
    // 設備狀態：閒置、忙碌、故障
    public enum EquipmentStatus { Idle, Busy, Down }


    //定義名為Lot的物件種類
    public class Lot
    {
        //string: 只能填文字, = string.Empty: 預設為空字串, 就不會是null
        //get: 准許別人看, set: 准許別人改
        public string Id { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;

        //= LotStatus.Wait：預設貨剛被建出來時，狀態是Wait
        public LotStatus Status { get; set; } = LotStatus.Wait;
        
        //?: 這代表這個欄位「可以沒有資料」, 可能在等機台
        public string? CurrentEquipmentId { get; set; }
    }

    public class Equipment
    {
        public string Id { get; set; } = string.Empty;
        
        //預設閒置
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Idle;
        
        // 目前正在加工的產品類型，空值代表閒置
        public string? CurrentLotTypes { get; set; }
    }
}