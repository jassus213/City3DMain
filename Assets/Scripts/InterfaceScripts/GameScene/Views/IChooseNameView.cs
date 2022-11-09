public interface IChooseNameView
{
    void SetPresenter(IChooseNamePresenter presenters);

    void Show(bool show);

    string GetCityName();

    void SetCityName(string name);

    void ErrorCityName(string textError);
}