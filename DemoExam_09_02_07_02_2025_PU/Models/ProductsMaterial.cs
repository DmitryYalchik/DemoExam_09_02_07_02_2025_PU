using System;
using System.Collections.Generic;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Материалы продукции
/// </summary>
public partial class ProductsMaterial
{
    /// <summary>
    /// Код Материала
    /// </summary>
    public int MaterialId { get; set; }

    /// <summary>
    /// Код Продукции
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Необходимое количество материала
    /// </summary>
    public decimal Coef { get; set; }

    /// <summary>
    /// Объект Материала
    /// </summary>

    public virtual Material Material { get; set; } = null!;

    /// <summary>
    /// Объект Продукции
    /// </summary>
    public virtual Product Product { get; set; } = null!;
}
