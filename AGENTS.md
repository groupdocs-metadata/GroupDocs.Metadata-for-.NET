# GroupDocs.Metadata for .NET — AGENTS.md

> Instructions for AI agents working with **.NET** examples in this repository.

GroupDocs.Metadata for .NET lets applications read, search, edit, and remove metadata — including EXIF, XMP, IPTC, Office properties, PDF info, and ID3 — from **110+** document, image, audio, video, archive, font, CAD, GIS, and ebook formats, without Microsoft Office or Adobe dependencies.

**Supported formats:** **110+** file formats — authoritative table: [https://docs.groupdocs.com/metadata/net/supported-document-formats/](https://docs.groupdocs.com/metadata/net/supported-document-formats/)

**Human overview:** see [README.md](README.md) in this repository.

## Install

Add the NuGet package to your project or the sample `.csproj`:

```powershell
dotnet add package GroupDocs.Metadata
```

Or via Package Manager Console:

```powershell
Install-Package GroupDocs.Metadata
```

Package page: [https://www.nuget.org/packages/GroupDocs.Metadata/](https://www.nuget.org/packages/GroupDocs.Metadata/)

## Resources

| Resource | URL |
|---|---|
| Documentation | [https://docs.groupdocs.com/metadata/net/](https://docs.groupdocs.com/metadata/net/) |
| API reference | [https://reference.groupdocs.com/metadata/net/](https://reference.groupdocs.com/metadata/net/) |
| Code examples (this repo) | [https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET](https://github.com/groupdocs-metadata/GroupDocs.Metadata-for-.NET) |
| Release notes | [https://releases.groupdocs.com/metadata/net/](https://releases.groupdocs.com/metadata/net/) |
| Package (NuGet) | [https://www.nuget.org/packages/GroupDocs.Metadata/](https://www.nuget.org/packages/GroupDocs.Metadata/) |
| Free support forum | [https://forum.groupdocs.com/c/metadata/](https://forum.groupdocs.com/c/metadata/) |
| Temporary license | [https://purchase.groupdocs.com/temp-license](https://purchase.groupdocs.com/temp-license) |

## MCP server (optional)

For IDE agents that support MCP, see [https://github.com/groupdocs-metadata/GroupDocs.Metadata.Mcp](https://github.com/groupdocs-metadata/GroupDocs.Metadata.Mcp). This examples repository demonstrates the **on-premise SDK** path.

## License

Apply a GroupDocs license before processing files without evaluation limitations:

```csharp
using GroupDocs.Metadata;

// Call once at application startup
new License().SetLicense("path/to/GroupDocs.Metadata.lic");
```

Use a [temporary license](https://purchase.groupdocs.com/temp-license) for local development. Do not commit license files to this repository.

## API entry points

| Surface | Type | Notes |
|---------|------|-------|
| **This SDK** | `GroupDocs.Metadata.Metadata` | Primary entry — `using GroupDocs.Metadata;` |
| **Cloud .NET SDK** | `GroupDocs.Metadata.Cloud.*` / `MetadataApi` | **Not used in this repo** — requires Cloud credentials |
| **MCP** | MCP tools `ReadMetadata`, `RemoveMetadata` | Separate repo — [https://github.com/groupdocs-metadata/GroupDocs.Metadata.Mcp](https://github.com/groupdocs-metadata/GroupDocs.Metadata.Mcp) |

Typical SDK pattern:

```csharp
using (var metadata = new Metadata("input.pdf"))
{
    // read / edit / sanitize / save
    metadata.Save("output.pdf");
}
```

API reference: [https://reference.groupdocs.com/metadata/net/](https://reference.groupdocs.com/metadata/net/)

## Example projects

<!-- Filled at generation time from repository tree and README headings. -->

Sample folders under `Examples/`:
- `Examples/GroupDocs.Metadata.Examples.CSharp/`
- `Examples/GroupDocs.Metadata.Examples.CSharp.Core/`
- `Examples/GroupDocs.Metadata.Examples.CSharp.Framework/`

Topics from [README.md](README.md):
- Document Metadata Processing Features
- Read & Write Metadata
- Develop & Deploy GroupDocs.Metadata Anywhere
- Get Started with GroupDocs.Metadata for .NET
- Remove All Metadata Properties from a PDF
- Extract Metadata from Various Files

## Commands you can run

From the repository root (adjust project path to the sample you are running):

```bash
dotnet restore
dotnet build
dotnet run --project Examples/<SampleProject>/<SampleProject>.csproj
```

If a solution file (`.sln`) is present at the root, prefer building through it:

```bash
dotnet build GroupDocs.Metadata.sln
```

## House rules

1. **Stay on-platform** — generate **.NET** code only; do not mix C#, Java, Python, and Node.js snippets from other GroupDocs.Metadata platforms unless the user explicitly asks for a comparison.
2. **Use canonical format count** — say **110+** (link to the formats table); never invent `60+`, `70+`, or `50+` counts.
3. **Prefer samples in this repo** — when adding or fixing examples, follow existing folder and naming conventions; reuse bundled sample files under `Examples/` (or equivalent) when present.
4. **License before full runs** — evaluation builds work with limitations until `SetLicense` / `setLicense` is applied; document the license path when adding new entry points.
5. **Link official docs** — API details belong in [https://reference.groupdocs.com/metadata/net/](https://reference.groupdocs.com/metadata/net/); keep AGENTS.md oriented to repository navigation and safe defaults.
6. **Do not commit secrets** — license files, Cloud client secrets, and API keys stay out of git.

## Do not change

- Do not delete or rewrite bundled sample documents/images used by existing examples.
- Do not change the NuGet / Maven / PyPI / npm package id (`GroupDocs.Metadata`) in install instructions.
- Do not replace SDK entry types with Cloud SDK types (`MetadataApi`, etc.).
- Do not add unrelated GroupDocs products (Conversion, Viewer, etc.) unless the sample explicitly requires them.
- Do not remove evaluation/license setup from runnable entry points without an explicit maintainer request.
