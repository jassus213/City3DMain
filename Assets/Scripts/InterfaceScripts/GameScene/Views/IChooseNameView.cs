public interface IChooseNameView
{
    void SetPresenter(IChooseNamePresenter presenter);

    void Show(bool show);

    void SetCityName(string text);
}