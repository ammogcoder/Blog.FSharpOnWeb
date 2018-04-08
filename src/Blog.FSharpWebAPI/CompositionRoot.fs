module CompostionRoot

open Blog.FSharpWebAPI.Repositories
open Blog.FSharpWebAPI.DataAccess
open Blog.FSharpWebAPI.Models

open Microsoft.EntityFrameworkCore

let configureSqlServerContext = 
    (fun () ->
        let optionsBuilder = new DbContextOptionsBuilder<LabelsContext>();
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=ContentData;User Id=sa;
                                      Password=P@55w0rd;") |> ignore
        new LabelsContext(optionsBuilder.Options)
    )

let getContext = configureSqlServerContext()
let getLabel  = LabelsRepository.getLabel getContext
let addLabel = LabelsRepository.addLabel getContext
let addLabelAsync = LabelsRepository.addLabelAsync getContext
let updateLabel = LabelsRepository.updateLabel getContext
let deleteLabel = LabelsRepository.deleteLabel getContext
