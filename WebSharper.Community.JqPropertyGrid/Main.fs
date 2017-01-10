namespace WebSharper.Community.JqPropertyGrid

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =


    let JqPropertyGrid = Class "JqPropertyGrid"
                         |+> Static [
                           "create" => T<Dom.Element>?el * T<obj>?theObj * T<obj>?theMeta ^-> T<unit> |>  WithInline  "jQuery($el).jqPropertyGrid($theObj,$theMeta)" 
                         ] 

    let Assembly =
        Assembly [
            Namespace "WebSharper.Community.JqPropertyGrid" [
                 JqPropertyGrid
            ]
            Namespace "WebSharper.Community.JqPropertyGrid.Resources" [
                //Resource "jqueryui_" "//ajax.googleapis.com/ajax/libs/jqueryui/1.11.1/jquery-ui.min.js"
                Resource "JqPropertyGrid" "jqPropertyGrid.js"
                |> fun r -> r.AssemblyWide()
            ]

        ]

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
