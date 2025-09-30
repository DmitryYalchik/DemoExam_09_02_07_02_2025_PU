using System;
using System.Collections.Generic;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Тип продукции
/// </summary>
public partial class ProductsType
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
    /// Коэффициент типа продукции
    /// </summary>
    public decimal Coef { get; set; }

    /// <summary>
    /// Продукция, в которых используется данный Тип продукции
    /// </summary>

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
