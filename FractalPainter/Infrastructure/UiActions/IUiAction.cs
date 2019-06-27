namespace FractalPainting.Infrastructure.UiActions
{
    public interface IUiAction
    {
        CategoryType Category { get; }
        string Name { get; }
        string Description { get; }
        void Perform();
    }
}