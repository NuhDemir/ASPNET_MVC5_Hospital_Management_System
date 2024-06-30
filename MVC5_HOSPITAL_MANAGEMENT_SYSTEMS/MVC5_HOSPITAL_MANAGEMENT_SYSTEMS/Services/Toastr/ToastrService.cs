using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS
{
    public static class ToastrService
    {
        // Bu bir toastr servisi
        private static readonly List<(DateTime Date, string SessionID, Toastr Toastr)> _toastrs =
            new List<(DateTime Date, string SessionID, Toastr Toastr)>();

        // Oturum kimliğini alır
        private static string GetSessionID()
        {
            return HttpContext.Current.Session.SessionID;
        }

        // Kullanıcı kuyruğuna toastr ekler
        public static void AddToUserQueue(Toastr toastr)
        {
            _toastrs.Add((Date: DateTime.Now, SessionID: GetSessionID(), Toastr: toastr));
        }

        // Mesaj, başlık ve tür bilgileriyle kullanıcı kuyruğuna toastr ekler
        public static void AddToUserQueue(string message, string title, ToastrType type)
        {
            AddToUserQueue(new Toastr(message, title, type));
        }

        // Kullanıcının kuyruğunda öğe var mı kontrol eder
        public static bool HasUserQueue()
        {
            string sessionId = GetSessionID();
            return _toastrs.Any(x => x.SessionID == sessionId);
        }

        // Kullanıcının kuyruğundaki tüm öğeleri kaldırır
        public static void RemoveUserQueue()
        {
            string sessionId = GetSessionID();
            _toastrs.RemoveAll(x => x.SessionID == sessionId);
        }

        // Tüm toastrları temizler
        public static void ClearAll()
        {
            _toastrs.Clear();
        }

        // Kullanıcının kuyruğundaki öğeleri okur
        public static List<(DateTime Date, string SessionID, Toastr Toastr)> ReadUserQueue()
        {
            string sessionId = GetSessionID();
            return _toastrs.Where(x => x.SessionID == sessionId).OrderBy(x => x.Date).ToList();
        }

        // Kullanıcının kuyruğundaki öğeleri okur ve kaldırır
        public static List<(DateTime Date, string SessionID, Toastr Toastr)> ReadAndRemoveUserQueue()
        {
            var list = ReadUserQueue();
            RemoveUserQueue();
            return list;
        }
    }

}