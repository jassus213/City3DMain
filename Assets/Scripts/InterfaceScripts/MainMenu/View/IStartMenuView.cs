public interface IStartMenuView
{
    void SetPresenter(IMainMenuPresenter presenter);

    void Show(bool show);
    
}