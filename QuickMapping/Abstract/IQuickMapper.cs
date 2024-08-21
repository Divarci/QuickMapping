namespace QuickMapping.Abstract;
public interface IQuickMapper
{
    /// <summary>
    /// There are two <strong>params</strong> required. Creates new instance of <strong>destination</strong> type
    /// <list type="number">
    /// <item><param name="source">The <em>source</em> object</param></item>
    /// <item><param name="depth">The count of mapping <em>depth</em></param></item>
    /// </list>
    /// </summary>
    /// <returns>The <strong>mapped object</strong>.</returns>
    Destination Map<Source, Destination>(Source source, int depth);

    /// <summary>
    /// There are three <strong>params</strong> required. Uses existing instance of <strong>destination</strong> type
    /// <list type="number">
    /// <item><param name="source">The <em>source</em> object</param></item>
    /// <item><param name="destination">The <em>destination</em> object</param></item>
    /// <item><param name="depth">The count of mapping <em>depth</em></param></item>
    /// </list>
    /// </summary>
    /// <returns>The <strong>mapped object</strong>.</returns>
    Destination Map<Source, Destination>(Source source, Destination destination, int depth);
}