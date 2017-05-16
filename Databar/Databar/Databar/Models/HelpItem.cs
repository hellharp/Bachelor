namespace Databar.Models
{
    /// <summary>
    /// Model for each element in a view that might need explanation
    /// </summary>
    public class HelpItem
    {
        public string _TextAnd;
        /// <summary>
        /// String which points to which element that needs explanation if there is no image
        /// </summary>
        public string ItemText { get; set; }

        /// <summary>
        /// String that explains the chosen element
        /// </summary>
        public string Explanation { get; set; }

        /// <summary>
		/// String outputs the ItemText and Explanation
		/// </summary>
		public string TextAnd { get { return ItemText + ":\n" + Explanation + "\n"; } set { _TextAnd = value; } }
    }
}