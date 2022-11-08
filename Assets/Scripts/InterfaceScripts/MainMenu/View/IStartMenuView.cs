public interface IStartMenuView
{
    void SetPresenter(IStartMenuPresenter presenter);

    void Show(bool show);
}