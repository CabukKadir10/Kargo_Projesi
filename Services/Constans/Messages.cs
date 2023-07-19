using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Constans
{
    public static class Messages
    {
        public static string CreatedLine = "Line Oluşturma Başarılı";
        public static string DeletedLine = "Line Silme Başarılı";
        public static string UpdatedLine = "Line Güncelleme Başarılı";

        public static string DeletedStation = "Station Silme Başarılı";
        public static string UpdatedStation = "Station Güncelleme Başarılı";

        public static string CreatedCenter = "TransferCenter Oluşturma Başarılı";
        public static string HardDeleted = "TransferCenter HardDelete Başarılı";
        public static string UpdatedCenter = "TransferCenter Güncelleme Başarılı";
        public static string CancelDeleted = "TransferCenter Silme işlemi İptal Edildi";
        public static string Deleted = "TransferCenter Silme işlemi Başarılı(Seed Data)";

        public static string RegisterUser = "Kullanıcı Kaydı Oluşturuldu";
        public static string UpdatedUser = "Kullanıcı Güncelleme Başarılı";
    }
}
