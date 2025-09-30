using System;
using System.Collections.Generic;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Единица измерения
/// </summary>
public partial class Unit
{
    /// <summary>
    /// Код
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Краткое наименование
    /// </summary>
    public string ShortName { get; set; } = null!;

    /// <summary>
    /// Материалы, в которых используется данная Единица измерения
    /// </summary>

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
