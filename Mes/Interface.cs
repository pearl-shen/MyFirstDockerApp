// 1. 位置: MyFirstApp/Services/IMesService.cs
using MyFirstApp.MesModel;

namespace MyFirstApp.Services;

// 定義必須有MoveIn功能
public interface IMesService
{
    bool MoveIn(Lot lot, Equipment eq);
}