namespace BasicSample


module Counter =
    open Avalonia.Controls
    open Avalonia.FuncUI.DSL
    open Avalonia.Layout
    open XTargets.Elmish
    
    type State = { count : int }
    let init = { count = 0 }

    
    let view (state: Lens<State>) =
        let updateIncrement (state: Lens<State>) =
            { state.Get with count = state.Get.count + 1 } |> state.Set

        let updateDecrement (state: Lens<State>) =
            { state.Get with count = state.Get.count - 1 } |> state.Set

        let updateReset (state: Lens<State>) =
            { state.Get with count = 0 } |> state.Set

        DockPanel.create [
            DockPanel.children [
                Button.create [
                    Button.dock Dock.Bottom
                    Button.onClick (fun _ -> updateReset state)
                    Button.content "reset"
                ]                
                Button.create [
                    Button.dock Dock.Bottom
                    Button.onClick (fun _ -> updateDecrement state)
                    Button.content "-"
                ]
                Button.create [
                    Button.dock Dock.Bottom
                    Button.onClick (fun _ -> updateIncrement state)
                    Button.content "+"
                ]
                TextBlock.create [
                    TextBlock.dock Dock.Top
                    TextBlock.fontSize 48.0
                    TextBlock.verticalAlignment VerticalAlignment.Center
                    TextBlock.horizontalAlignment HorizontalAlignment.Center
                    TextBlock.text (string state.Get.count)
                ]
            ]
        ]       