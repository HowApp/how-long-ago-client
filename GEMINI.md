# `how-long-ago-client` (`HowClient`) — Context & Rules

## Overview
Blazor WebAssembly SPA (`net8.0`) using `Blazor.Bootstrap`, OIDC Authentication (`how-web-client`), SignalR Client (`/hubs/fileProcessing`), and typed HTTP services (`EventPublicService`, `RecordPublicService`, `EventPrivateService`, `RecordPrivateService`, `InternalNotificationService`).

## Rules
- All pages with timers (`System.Timers.Timer`) or `InternalNotificationService.OnError` handlers MUST implement `IDisposable` (and `IAsyncDisposable` if managing SignalR `HubConnection`) to stop/dispose timers and unsubscribe from events.
- Modal dynamic parameters (`_modal.ShowAsync<T>`) must match parameter names with exact case (`"OnClickCallback"`).
- Use `await InvokeAsync(StateHasChanged)` inside timer elapsed callbacks.
