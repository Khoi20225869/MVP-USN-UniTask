using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UI.CustomizePage;
using UI.GaragePage;
using UI.MainPage;
using UI.SettingModal;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Page;
using System;

public static class TransitionService
{
    private static PageContainer PageContainer => PageContainer.Find("PageContainer");
    private static ModalContainer ModalContainer => ModalContainer.Find("ModalContainer");

    // Page
    public static async UniTask TransitionToMainPage()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return;
        
        await PageContainer.Push(DefaultKey.MainPage, true, onLoad: x =>
        {
            var page = x.page;
            var view = page.GetComponent<MainView>();
            var presenter = new MainPresenter(view);

            page.AddLifecycleEvent(onWillPushEnter: WillPushEnter, onWillPopExit: WillPopExit);
            return;

            async Task WillPushEnter()
            {
                view.Init();
                await PageContainer.Preload(DefaultKey.GaragePage);
            }

            Task WillPopExit()
            {
                presenter.Release();
                PageContainer.ReleasePreloaded(DefaultKey.GaragePage);
                return Task.CompletedTask;
            }
        });
    }

    public static async UniTask  TransitionToGaragePage()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return;
        
        await PageContainer.Push(DefaultKey.GaragePage, true, onLoad: x =>
        {
            var page = x.page;
            var view = page.GetComponent<GarageView>();
            var presenter = new GaragePresenter(view);

            page.AddLifecycleEvent(onWillPushEnter: WillPushEnter, onWillPopExit: WillPopExit);
            return;

            async Task WillPushEnter()
            {
                view.Init();
                await PageContainer.Preload(DefaultKey.CustomizePage);
            }

            Task WillPopExit()
            {
                presenter.Release();
                PageContainer.ReleasePreloaded(DefaultKey.CustomizePage);
                return Task.CompletedTask;
            }
        });
    }

    public static async UniTask TransitionToCustomizePage()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return;
        
        await PageContainer.Push(DefaultKey.CustomizePage, true, onLoad: x =>
        {
            var page = x.page;
            var view = page.GetComponent<CustomizeView>();
            var presenter = new CustomizePresenter(view);
            
            page.AddLifecycleEvent(onWillPushEnter: WillPushEnter, onWillPopExit: WillPopExit);
            return;

            Task WillPushEnter()
            {
                view.Init();
                return Task.CompletedTask;
            }

            Task WillPopExit()
            {
                presenter.Release();
                return Task.CompletedTask;
            }
        });
    }

    
    // Modal
    public static async UniTask TransitionToSettingModal()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return;
        
        await ModalContainer.Push(DefaultKey.SettingsModal, true, onLoad: x =>
        {
            var modal = x.modal;
            var view = modal.GetComponent<SettingView>();
            var presenter = new SettingPresenter(view);

            modal.AddLifecycleEvent(onWillPushEnter: WillPushEnter, onWillPopExit: WillPopExit);
            return;

            Task WillPushEnter()
            {
                view.Init();
                return Task.CompletedTask;
            }

            Task WillPopExit()
            {
                presenter.Release();
                return Task.CompletedTask;
            }
        });
    }

    public static async UniTask TransitionBackPage()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return; 
        
        await PageContainer.Pop(true);
    }

    public static async UniTask TransitionBackModal()
    {
        if (PageContainer.IsInTransition || ModalContainer.IsInTransition)
            return;

        await ModalContainer.Pop(true);
    }

}
