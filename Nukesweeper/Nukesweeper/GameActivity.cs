﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;
using Microsoft.Xna.Framework;

using Game = TeamStor.Engine.Game;
using Android.Views;
using TeamStor.PuzzleAndroidGame.Menu;

namespace TeamStor.PuzzleAndroidGame
{
    // https://github.com/MonoGame/MonoGame.Samples/blob/develop/Platformer2D/Platforms/Android/Activity1.cs
    [Activity(
        Label = "Puzzle Android Game",
        MainLauncher = true,
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden)]
    public class GameActivity : AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Game teamStorGame = new Game(new MenuState());
            SetContentView((View)teamStorGame.Services.GetService(typeof(View)));

            SystemUiFlags uiOptions = SystemUiFlags.HideNavigation |
                SystemUiFlags.LayoutHideNavigation |
                SystemUiFlags.Fullscreen |
                SystemUiFlags.LayoutStable |
                SystemUiFlags.LowProfile |
                SystemUiFlags.Immersive |
                SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            teamStorGame.Stats |= Game.DebugStats.FPS;
            teamStorGame.Run();
        }
    }
}