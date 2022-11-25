public interface IMainMenuView
{
    void SetPresenter(IMainMenuPresenter presenter);

    void Show(bool show);
    
}