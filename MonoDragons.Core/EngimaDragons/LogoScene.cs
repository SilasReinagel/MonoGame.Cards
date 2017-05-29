using System;
using System.Threading.Tasks;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace MonoDragons.Core.EngimaDragons
{
    public class LogoScene : IScene
    {
        private bool _begunTransition;
        private bool _transitionComplete;

        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, NavigateToMainMenu);
        }

        private void NavigateToMainMenu()
        {
            if (_transitionComplete)
                return;

            _transitionComplete = true;
            World.NavigateToScene("Intro");
        }

        public async void Update(TimeSpan delta)
        {
            if (_begunTransition)
                return;

            _begunTransition = true;
            await Task.Delay(2000);
            NavigateToMainMenu();
        }

        public void Draw()
        {
            UserInterface.UI.DrawCentered("Images/Logo/enigmadragons-presents");
        }
    }
}
