# Andrew Allbright Unity Tools
`Allbright Tools` represents a collection of code and assets to help me (Andrew Allbright) create Unity projects more rapidly.

### Development instructions
`Allbright Tools` is a Unity Package Manager (UPM) custom package. The project is set up as an [embedded package](https://docs.unity3d.com/Manual/CustomPackages.html#EmbedMe).

You have two choices for developing new code or assets... You can open the Unity project (AA Unity Tools) within this repo...

The second choice is to import `Allbright Tools` as a [custom package from file](https://docs.unity3d.com/Manual/upm-localpath.html). This allows the package contents to be writeable. Clone this repo, create a separate new Unity project (as it's own git repo), and import a custom package from file inside Unity's Package Manager window.

If you choose this second choice and you want to run tests from the custom package (as you make changes/add new content), you will have to update `testables` property in your `Packages/manifest.json` file for your separate new Unity project.
```
  },
  "testables": [
    "com.andrewallbright.allbrighttools"
  ]
```

If you choose the second choice any changes you make in the locally install package will be contained in the original clone of this repo. Any version control for this library must occur in the cloned repo.

I recommend the second choice.

#### Is this code or asset a project specific asset or a library asset?
Good question. Presuming you are using the second method above, I recommend starting out the code or asset in the new unity project's Asset folder. Then if it "makes sense" then promote what it is from a project specific asset to a `Allbright Tools` library asset.

### Build instructions
1. Develop, test codebase/assets. Commit.
1. Tag version of code. Push to github.
1. Open unity project.
1. (Optional) Export asset pack
	1. Packes/com.andrewallbright.allbrightools/Assets -> Export Package... (Right clicking folder also works)
	1. Save as `andrewallbright-tools.unitypackage`
1. Add to build artifacts to a github release on github.


#### Install using a git URL
You would want to do this if you do not plan on making additions to `Allbright Tools`.

Install Allbright Tools using a git URL (latest version)
```bash
https://github.com/aallbrig/unity-tools.git?path=AA Unity Tools/Packages/com.andrewallbright.allbrighttools
```

Install Allbright Tools using a git URL but pinned to a specific version
```bash
https://github.com/aallbrig/unity-tools.git?path=AA Unity Tools/Packages/com.andrewallbright.allbrighttools#v0.0.16
```

## Roadmap
1. Execute `Edit Mode` tests as a continuous integration (CI) step. ([game-ci/unity-actions](https://github.com/game-ci/unity-actions) is a github actions solutions)
1. Execute `Play Mode` tests as a CI step. ([game-ci/unity-actions](https://github.com/game-ci/unity-actions) is a github actions solutions)
1. On git tag, add new github release that shares the same name as the git tag.
1. On git tag, produce a `WebGL` project build as a CI step. ([game-ci/unity-actions](https://github.com/game-ci/unity-actions) is a github actions solutions)
1. On git tag, zip up `WebGL` project build as a CI step.
1. On git tag, add zipped up `WebGL` build artifacts (.zip) to newly created github release as a CI step.
1. (Keyboard) Top down controller.
1. (Mouse) Aim controller.
1. (Mouse + Keyboard) RTS/MOBA controller.


---
Ideas...
UI manager? UI state machine?

---
Big thanks to [this blog by Naga Chiang](https://nagachiang.github.io/tutorial-working-with-custom-package-in-unity-2019-2/#) for helping to keep custom packages more simple than the official unity documentation!

