namespace WebSharper.Community.JqPropertyGrid.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.Html.Client
open WebSharper.JQuery
open WebSharper.Community.JqPropertyGrid

[<JavaScript>]
module Client =


    let Main () =
    let propertiesDiv=Div[]

    let propsJson="""
    {
        "theObj":
        {
          "font": "Consolas",
          "fontSize": 14,
          "fontColor": "#a3ac03",
          "jQuery": true,
          "modernizr": false,
          "framework": "angular",
          "iHaveNoMeta": "Never mind...",
          "iAmReadOnly": "I am a label which is not editable"
        },
        "theMeta":
        {
            "font": { "group": "Editor", "name": "Font", "description": "The font editor to use"},
            "fontSize": { "group": "Editor", "name": "Font size", "type": "number", "options": { "min": 0, "max": 20, "step": 2 }},
            "fontColor": { "group": "Editor", "name": "Font color", "type": "color", "options": { "preferredFormat": "hex" }},
            "jQuery": { "group": "Plugins", "description": "Whether or not to include jQuery on the page" },
            "modernizr": {"group": "Plugins", "type": "boolean", "description": "Whether or not to include modernizr on the page"},
            "framework": {"name": "Framework", "group": "Plugins", "type": "options", "options": ["None", {"text":"AngularJS", "value": "angular"}, {"text":"Backbone.js"," value": "backbone"}], "description": "Whether to include any additional framework"},
            "iAmReadOnly": { "name": "I am read only", "type": "label", "description": "Label types use a label tag for read-only properties", "showHelp": false }


        }
    }
    """
    let treeContent = JQuery.ParseJSON(propsJson)
    let props=JqPropertyGrid.Create(propertiesDiv.Dom,treeContent?theObj,treeContent?theMeta)



    Div [propertiesDiv]
