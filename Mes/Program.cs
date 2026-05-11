using Microsoft.AspNetCore.Builder;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. 定義資料
var myLot = new { Id = "L01", Status = "Wait" };
var myEq = new { Id = "EQ-01", Status = "Idle" };

// 2. 網頁路徑
app.MapGet("/trackin", () => {
    if (myLot.Status == "Wait" && myEq.Status == "Idle") 
    {
        return $"[成功] 貨物 {myLot.Id} 已經進入機台 {myEq.Id}！";
    }
    return "[失敗] 狀態不符。";
});

// 3. 啟動訊息
Console.WriteLine("--- MES 系統啟動中 ---");
app.Run();