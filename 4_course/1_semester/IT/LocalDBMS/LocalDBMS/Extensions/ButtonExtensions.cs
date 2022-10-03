using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

public static class ButtonExtensions
{
    public static void RemoveClickEvent(this Button button)
    {
        var field = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);

        object obj = field.GetValue(button);
        var pi = button.GetType().GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);

        var list = (EventHandlerList)pi.GetValue(button, null);
        
        list.RemoveHandler(obj, list[obj]);
    }
}