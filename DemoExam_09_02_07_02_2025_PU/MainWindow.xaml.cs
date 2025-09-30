using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoExam_09_02_07_02_2025_PU.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoExam_09_02_07_02_2025_PU
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData(); /* Модуль 2 */
        }

        /// <summary>
        /// Модуль 2
        /// Загрузка данных в <see cref="materialsList_IC"/>
        /// </summary>
        public void LoadData()
        {
            try
            {
                using (DemoExam090207022025PuContext db = new ())
                {
                    var list = db.Materials.Include(x => x.Unit).Include(x => x.Type).ToList();
                    list.ForEach(m =>
                    {
                        // Суммируем коэффициенты
                        //m.NeedQuantity = db.ProductsMaterials.Where(mp => mp.MaterialId == m.Id).Sum(mp => mp.Coef);

                        // Суммируем коэффициенты * количетсво материала в упаковке
                        // Если используете первый вариант, измените StringFormat у соответствующего поля в MainWindow.xaml
                        m.NeedQuantity = db.ProductsMaterials.Where(mp => mp.MaterialId == m.Id).Sum(mp => mp.Coef * m.QuantityInPack);
                    });
                    materialsList_IC.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", $"Произошла ошибка при подключении к базе данных\nСообщение: {ex.Message ?? ex.InnerException?.Message}", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}