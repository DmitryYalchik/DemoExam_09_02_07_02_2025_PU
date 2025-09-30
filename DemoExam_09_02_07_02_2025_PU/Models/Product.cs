using System;
using System.Collections.Generic;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Продукция
/// </summary>
public partial class Product
{
    /// <summary>
    /// Код
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Артикул
    /// </summary>
    public string Article { get; set; } = null!;

    /// <summary>
    /// Минимальная цена
    /// </summary>
    public decimal MinimalCost { get; set; }

    /// <summary>
    /// Код Типа продукции
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Объект Типа продукции
    /// </summary>
    public virtual ProductsType Type { get; set; } = null!;
}
