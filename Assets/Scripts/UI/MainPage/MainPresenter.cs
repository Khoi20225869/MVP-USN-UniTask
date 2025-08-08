namespace UI.MainPage
{
    public class MainPresenter
    {
        private readonly MainView _view;
        
        public MainPresenter(MainView view)
        {
            _view = view;
            Init();
        }

        private void Init()
        {
            MainEventManager.Instance.OnPlayClicked += HandlePlayerClicked;
            MainEventManager.Instance.OnPauseClicked += HandlePauseClicked;
            MainEventManager.Instance.OnGarageClicked += HandleGarageClicked;
        }

        public void Release()
        {
            MainEventManager.Instance.OnPlayClicked -= HandlePlayerClicked;
            MainEventManager.Instance.OnPauseClicked -= HandlePauseClicked;
            MainEventManager.Instance.OnGarageClicked -= HandleGarageClicked;
        }
        
        private void HandlePlayerClicked()
        {
            //Debug.Log("Player clicked");
        }
    
        private void HandlePauseClicked()
        {
            //Debug.Log("Pause clicked");
        }
        private void HandleGarageClicked()
        {
            //Debug.Log("Customize clicked");
            _ = TransitionService.TransitionToGaragePage();
        }
    }
}