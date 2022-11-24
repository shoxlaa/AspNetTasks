using MvcWebApplication1.Models;
namespace MvcWebApplication1.Services
{
    public interface INotesList
    {
        void AddItem(Note item);
        void RemoveItem(int index);
        IEnumerable<Note> GetItems();
    }
    public class NotesList : INotesList
    {
		private List<Note> _items = new();

		public void AddItem(Note item)
		{
			_items.Add(item);
			item.Id++;
		}

		public IEnumerable<Note> GetItems()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				yield return _items[i];
			}
		}

		public void RemoveItem(int index)
		{
			_items.RemoveAt(index);
		}
	}
}