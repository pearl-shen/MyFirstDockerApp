using Microsoft.AspNetCore.Builder;
using MyFirstApp.MesModel;   // 引用Model.cs
using MyFirstApp.Services;   // 引用Service.cs

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. 初始化資料：建立Lot與Equipment
var myLot = new Lot 
{ 
    Id = "L01", 
    Status = LotStatus.Wait 
};

var myEq = new Equipment 
{ 
    Id = "EQ-01", 
    Status = EquipmentStatus.Idle 
};

// 2. 建立Service
var mesService = new MesService();

// 3. 設定網頁路徑
// (): 代表不需要額外參數
// =>: 指向, 執行
// {}: 代表執行{}內程式
app.MapGet("/trackin", () => 
{
    // 呼叫Service裡的MoveIn方法進行邏輯判斷
    // 我們把資料交給 Service，會回傳true或false
    bool isSuccess = mesService.MoveIn(myLot, myEq);

    if (isSuccess)
    {
        return $"[成功] 透過 MesService 處理：貨物 {myLot.Id} 已進入機台 {myEq.Id}。";
    }
    else
    {
        return "[失敗] Service 判定狀態不符合進站要求。";
    }
});

Console.WriteLine("--- MES 系統已啟動 ---");

app.Run();