using System;
using System.Collections.Generic;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Тип материала
/// </summary>
public partial class MaterialsType
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
    /// Коэффициент потерь сырья
    /// </summary>
    public decimal LostCoef { get; set; }

    /// <summary>
    /// Материалы, в которых используется данный Тип материала
    /// </summary>
    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
