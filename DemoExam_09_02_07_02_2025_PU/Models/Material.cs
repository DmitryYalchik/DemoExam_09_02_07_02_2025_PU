using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoExam_09_02_07_02_2025_PU.Models;

/// <summary>
/// Модуль 2
/// Материалы
/// </summary>
public partial class Material
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
    /// Код Типа материала
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Цена за единицу
    /// </summary>
    public decimal CostPerUnit { get; set; }

    /// <summary>
    /// Количество на складе
    /// </summary>
    public decimal QuantityInStock { get; set; }

    /// <summary>
    /// Минимальное количество
    /// </summary>
    public decimal MinimalQuantity { get; set; }

    /// <summary>
    /// Количество в упаковке
    /// </summary>
    public decimal QuantityInPack { get; set; }

    /// <summary>
    /// Код единицы измерения
    /// </summary>
    public int UnitId { get; set; }

    /// <summary>
    /// Объект Типа материала
    /// </summary>
    public virtual MaterialsType Type { get; set; } = null!;

    /// <summary>
    /// Объект Единицы измерения
    /// </summary>
    public virtual Unit Unit { get; set; } = null!;

    /// <summary>
    /// Необходимое количество
    /// Заполняется вручную в <see cref="MainWindow.LoadData"/>
    /// </summary>
    [NotMapped]
    public decimal NeedQuantity { get; set; }
}
