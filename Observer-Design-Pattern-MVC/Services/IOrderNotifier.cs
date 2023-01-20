using System;
using Observer_Design_Pattern_MVC.Models;

namespace Observer_Design_Pattern_MVC.Services
{
    public interface IOrderNotifier
    {
        // Subjecte bir siparis observerı ekle.
        void Attach(IOrderObserver observer);

        // Subjectten bir siparis observerı cikart.
        void Detach(IOrderObserver observer);

        // Tum siparis observerlarını bir olay hakkinda bilgilendir.
        void Notify(Order order);
    }
}

