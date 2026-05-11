// 1. 該檔案位置: MyFirstApp資料夾的MesModel
namespace MyFirstApp.MesModel
{
    // 2. 定義Lot, Equipment狀態
    // public: 公開的, enum: 列舉
    // 批次狀態：等待中、生產中、已完成
    public enum LotStatus { Wait, Running, Finished }
    // 設備狀態：閒置、忙碌、故障
    public enum EquipmentStatus { Idle, Busy, Down }


    // 3. 定義Lot種類
    public class Lot
    {
        // string: 只能填文字
        // = string.Empty: 預設為空字串, 就不會是null
        // { get; set; }: 封裝屬性，允許外部讀取與修改
        public string Id { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;

        // 預設Lot的初始狀態是Wait
        public LotStatus Status { get; set; } = LotStatus.Wait;
        
        // string?: 這代表欄位「可以沒有資料」, 可能在等機台, 貨物尚未進站或處於緩衝區時，不會有對應的機台ID
        public string? CurrentEquipmentId { get; set; }
    }

    // 4. 定義Equipment種類
    public class Equipment
    {
        public string Id { get; set; } = string.Empty;
        
        //預設Equipment初始狀態是Idle(閒置)
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Idle;
        
        // 目前正在加工的產品類型，空值代表閒置
        public string? CurrentLotTypes { get; set; }
    }
}