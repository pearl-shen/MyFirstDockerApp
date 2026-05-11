// 1. 檔案位置: MyFirstApp資料夾的Services/MesService.cs
using MyFirstApp.MesModel;

namespace MyFirstApp.Services
{
    // 2. 實作邏輯：繼承IMesService
    public class MesService
    {
        // 3. 執行 進站(Move-In)方法
        // 傳入參數: 要進站的Lot與Equipment
        // 回傳bool(成功為true, 失敗為false)
        public bool MoveIn(Lot lot, Equipment eq)
        {
            // 3. 防呆驗證
            // 條件A: lot必須處於「等待中(Wait)」狀態
            // 條件B: eq必須處於「閒置(Idle)」狀態
            // 兩者同時成立(&&), 才符合生產安全規範
            if (lot.Status == LotStatus.Wait && eq.Status == EquipmentStatus.Idle)
            {
                // 4. 通過3後同時做以下
                // 4-1. 變更狀態：將lot從Wait標記為「生產中(Running)」
                lot.Status = LotStatus.Running;
                
                // 4-2. 變更狀態：將eq從Idle標記為「忙碌(Busy)」, 防止其他貨物重疊進入
                eq.Status = EquipmentStatus.Busy;
                
                // 4-3. 追蹤：將eq ID綁定到lot上, 紀錄目前位置
                lot.CurrentEquipmentId = eq.Id;
                
                // 流程檢核通過，回傳成功
                return true; 
            }
            
            // 5. 異常處理
            // 如果上述任一條件不符, 如機台當機或貨物已在生產, 則拒絕進站
            return false;
        }
    }
}