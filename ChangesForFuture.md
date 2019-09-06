# Changes for the Future

## About
I sat down and analyzed the code for a couple hours between two days (got through a bit over half the major scripts one day, the rest the next day) to look for what could be changed if I were to continue UE1 (which is possible, especially considering I have a mostly-finished re-vamp with new optimized models that never got released). UE1 demonstrates code that came from before I started learning C#/OOP in a formal academic setting. A lot of the suggested changes reflect both the lack of knowledge of C# itself and the lack of knowledge of OOP. Other changes are semantic (i.e. variable names, consistency, etc.). Some other changes are also just looking back at the code and realizing (which could occur without the need for new C#/OOP knowledge) what could be made better (e.g. some of the changes suggested to scenes that would make certain minimal scripts redundant).

## Overall
- Why does everything start with an underscore oh my lord
- Clearer variable names (no acronyms, esp. since _lm can mean both LoadManager and LevelManager (loadMgr or levelMgr is fine)
- A third of the code stems from the lack of setting up methods to use parameters or return values; in fact, at the time, I thought the only thing `void` could be changed to was `IEnumerator`
- Another third of the code stems from the bad habit of over-using coroutines, which creates memory overhead for the garbage collector
- Some code has `debug.Log()` statements that are no longer needed
- Some XML comments for methods and class definitions are needed

## "Major" Scripts (those outside MinimalScripts)
- Some of the scripts are too interdependent as well as expectant of things in all scenes, which has caused issues over time. Some of the fixes suggested later on would cut some of this interdependency, but some of the scripts may require a fundamental change in how they work in order to fully remove this interdependency. One scene that demonstrated the problem with this was the intro scene, which is a separate copy of one of the bases. The inspector reveals a lot of objects that are disabled that are only there to prevent NullReferenceExceptions

### [AIEntity](AIEntity.cs)
- Note: A lot of the entities behaved the same; splitting into fully functional child classes was good for expanding upon AI in UE2, but for the purpose of this project is unnecessary. 
- AIEntity shouldn't have had as much access to player components, such as the player's electrical damage sound and fire damage sound; the playing of those sounds should have been handled by the player
- Clean up appearance (specifically consistency) of `Update()` code (some opening {'s are inline, some are separate lines)
- Move the section of Damage into a separate `Damage()` method that's called upon when the player is in range, which is already checked earlier for following - prevents an unnecessary extra check and cleans up `Update()`
- Add an expValue variable that's set up with the other entity values in `Awake()`; use this in place of the conditionals in `Death()`

### [CutsceneManager](CutsceneManager.cs)
- Most of the start code and the number of IEnumerators could be shortened to use levelselected as a parameter for one method
- Cutscenes could be made into a class that holds values that change depending on the level, such as the wait time (`yield return new WaitForSeconds(xx)`), animation title, etc., and merge the idea of the CutsceneTransition class with this info); even better, levels could be turned into a class that holds information for both CutsceneManager and LevelManager to use
    - This class could then be used in an array that's created by another manager (possibly rename LevelManager to LevelHandler to use the name LevelManager for this) that is created upon game load and carried throughout the entire game (like SaveManager). This array would be instantiated by the manager's `Awake()`, defining all the values in a much neater way
- Don't overuse coroutines just for timers. Just create a timer with a conditional that executes once satisfied (i.e. `if (timer >= mentionedArray[levelSelected].waitTimeVariable) { // do stuff } else { timer += Time.deltaTime; }`)
- Since CutsceneManager is per-scene, cutscene cams should be assigned via inspector, not `GameObject.Find("")`; this applies to the objects found in methods like `IntroStuffStart()` such as the Player, any UI elements, any other cameras, etc.
- Don't use large black quads in world space for screen transitions - just use Unity UI (I have no idea why I used quads... it made animation more difficult)
- With above stuff in mind, structure CutsceneManager like so:
    - `Start()`: Find the scene-independent components (i.e. StoreManager, SaveManager, LoadManager) and run `Intro(float waitTime)`, passing through the wait time from the discussed array based on the level selected
    - `Intro(float waitTime)`: Basically serves the same function as `IntroStuffStart()` and `IntroStuffEnd()`, minus the unnecessary gameobject finding discussed earlier; sets up for cutscene playing, then sets up for game playing once a timer conditional is met
    - `Outro(float waitTime)`: Making similar changes as with Intro: set up for cutscene playing, wait for timer, handle cutscene end

### [GunManager](GunManager.cs)
- Ammo text should only be updated when gun is fired, not at the beginning of `Update()` every frame
- Refactor code so that the gun selection conditional appears only once per gun type, rather than animations-then-firing
- Move damage-related code to a `Damage()` method that's called when the Fire1 button is pressed - primarily for cleaning up `Update()`
- Possibly move animation code to a `GunAnimation()` method to further clean `Update()`, and instead of nesting conditionals, just use `&&`

### [HoverPlayerManager](HoverPlayerManager.cs)
- Inconsistent line-breaks for opening `{`s 
- `TakeDamage()`, `ToggleBuggy()`, and `Lights()` (rename to `ToggleLights()`) should just be `void` methods, not an `IEnumerator`
- The `Lights()` demonstrates a time that using `else if` didn't occur to me to avoid the problem of one conditional being entered, then the next being entered because the condition was changed in the first which causes the second to be satisfied, etc. The method was made into an `IEnumerator` with `yield break` to avoid it; in other earlier code, I sometimes reversed the order so that it couldn't fountain through conditionals. Changing to `else if` would be better. Same goes for `ToggleBuggy()` which does the same thing but for `if (_isInside == [bool-value-goes-here])`

### [LevelManager](LevelManager.cs)
- Make objectives-related variables into properties so that the setter runs the `UpdateDisplay()` function instead of entities/repair objects doing it
- Discussed before was the potential use of classes that hold values for level, which could be assigned via inspector. The `_difficultyEscalation` calculated in the `Awake()` function in LevelManager could be contained in that class, avoiding the numerous conditionals
- Make use of arrays for the `_obj#` variables which depend on the `_lm._basePart`, so that instead of the conditionals that are in `Start()`, could run a `for` loop that if `i == _lm._basePart`, run `SetActive(true)` at `obj[i]`, otherwise `SetActive(false)`
- All of the entities/repair conditionals in `Start()` would be avoided with the level-info class discussed
- Stop using coroutines for `Pause()`, `Unpause()`, `MMToggle()` (which has the `if` fountaining mentioned earlier), `COToggle()`, and `FLToggle()`
- Remove the conditionals in `UpdateHUD()` and directly make use of the variables instead (e.g., where `if (_COToggle == true) { _canvasObjectives.enabled = true }` and the statement for `false`, replace with `_canvasObjectives.enabled = _COToggle`)

### [LoadManager](LoadManager.cs)
- Use an array for _levelSelected and _basePart, where the index is the _levelSelected and the value stored is the _basePart
- The determination for tips should have a dedicated `DetermineTip()` method
- Pertaining to `load()` and `wait()` (which should be capitalized), these might have been coroutines due to online suggestions for working with asynchronous scene loading. Unlike previous coroutine changes discussed before, these might have to stay; however, I would have to see if UnityEngine.SceneManagement has had any changes after multiple Unity updates to see if this is true.

### [MusicManager](MusicManager.cs)
- MusicManager has had an ongoing bug where sometimes music doesn't play for a while. It also had a bug where if scene changes were too quick (e.g. exiting the intro scene), it wouldn't transition properly. Utilizing conditional timers in place of coroutines (which might not be stopping properly when being stopped by other scripts) might help fix this issue.
- `_currTrackWaitTime` could be a stored value in a 2D array, where the x-index is the `_levelSelected` conditional and the y-index is the `_randomTrackNo`. This would greatly condense `GetCurrTrack()` and optimize it since these wouldn't have to be calculated every time the coroutine (which, again, probably shouldn't be a coroutine) is run.
- Another array can be used for where in `StartLevelTrack(int _musicLevel)` the conditional `_musicLevel` could be the index and the stored value could be the `_randomTrackNo` that is used for the starting track for every scene (which is used to override calculating a random number for subsequent tracks when playing a level). This would again condense the method and prevent the calculation from occurring every new level

### [PlayerStats](PlayerStats.cs)
- Since PlayerStats was located with the player object, FirstPersonController and CharacterController should've been assigned via inspector
- HUD text should only be updated when a change occurs, not every frame like it is in the beginning of `Update()`
- Don't need coroutines for `WaitForStamina()` and `TakeDamage()`. Use conditional timer for `WaitForStamina()`. With `WaitForStamina()` this is the least necessary change, as no bugs arose that could potentially be from them like with others, but for consistency-sake, a timer would be preferred
- Electricity and fire UI and damage and sound functions should occur in PlayerStats, not AIEntity

### [SaveManager](SaveManager.cs)
- Remove all of the `WaitForSeconds(##)` in `Load()` and replace the coroutine with a normal void method.

### [SettingsManager](SettingsManager.cs)
- Use arrays for storing volumes. `_Music`, `_Enviro`, and `_Effects` would be the indices for their respective arrays, and the volumes would be the stored values. If the values remain identical between mixers like they are now, it may be better to use one array instead of three. This would greatly condense and clean `SetAudioFloats()`, and provide a bit of optimization since there wouldn't be conditionals being checked (instead `_mixer.SetFloat("mixer-name", mixer-array[chosen-mixer-setting])`). It would also condense `SetAllAudioFloats()`. In fact it may be better to simply remove `SetAudioFloats()` and rename `SetAllAudioFloats()` to `SetAudioFloats()` to simplify everything

### [SettingsMenuLoader](SettingsMenuLoader.cs)
- Other than some consistency with line-breaks and indenting, no changes seem to need to be made. Possibly move the functions of SettingsManager to this one, move the values of SettingsManager to a GameValues script (see StoreManager for this idea), and essentially delete SettingsManager and rename this one to SettingsManager

### [StoreManager](StoreManager.cs)
- This should be split into two different scripts - one that handles the actual functionality of the store (does not get `DontDestroyOnLoad()`), and one that carries stats between scenes for the player to grab (keeps the `DontDestroyOnLoad`). In fact, there could be a GameValues script that could transfer what values SettingsManager has to it and contain the stats from StoreManager so that the player would be grabbing information from one place rather than two (and therefore only calling `GameObject.FindWithTag()` once)
- Arrays should be utilized to store pre-determined values for upgrades so that less conditionals need checked and so that the code looks cleaner/more manageable/less hard-coded
- Again, don't use coroutines simply to avoid conditional fountaining (present with all of the `IEnumerator Get(ThisStat)()` methods); replace with `else if` statements

## [MinimalScripts](MinimalScripts/)
- Some of these can be made redundant/deprecated by changes in scenes or by changes in other aforementioned scripts. Continue reading for more information.

### [AIEntity_HealthMSG](MinimalScripts/AIEntity_HealthMSG.cs)
- While nothing is inherently wrong with this script itself, it comes from using mesh colliders on child objects rather than having a hitbox on the same object as AIEntity that the GunManager could do damage directly to AIEntity. This script therefore could be deleted once this change is made

### [BulletFade](MinimalScripts/BulletFade.cs)
- Use a conditional timer instead of a coroutine. No fundamental changes - this is simply to fade bullet-hole decals that appear where bullets impact

### [CutsceneTransition](MinimalScripts/CutsceneTransition.cs)
- Use a dictionary (`dictionary<int levelSelected, string[] uiText>`) to clean up the use of conditionals in `TransitionIntroBeginning()`

### [DoorOpener](MinimalScripts/DoorOpener.cs)
- Remove old commented-out code

### [Elevator](MinimalScripts/Elevator.cs)
- No changes necessary to the elevator script itself based off of current code that hasn't already been suggested for all scripts; however, a smoother transition would be desired for elevators in-game

### [EntityChunkLoading](MinimalScripts/EntityChunkLoading.cs)
- No changes necessary that hasn't already been suggested for all scripts; this script simply keeps only entities in a certain "chunk" that is in range of the player enabled to optimize larger scenes

### [FPSDisplay](MinimalScripts/FPSDisplay.cs)
- Use Unity UI instead of UnityGUI (deprecated)

### [InteractableObject](MinimalScripts/InteractableObject.cs)
- Input should be one parent conditional that contains the `object == #` conditionals; condenses and optimizes `Update()` since only one conditional would be checked if there's no input rather than 6

### [LampLightOff](MinimalScripts/LampLightOff.cs)
- Possibly rename the script since this also turns lights on... (this optimizes lighting in the scene so only lamps in range turn on)

### [LensFlareFixedDistance](MinimalScripts/LensFlareFixedDistance.cs)
- No changes necessary that haven't already been suggested for all scripts; this script simply resizes lens flares so that they're smaller for distant objects, primarily for lamps and other small lights; lens flares are overused in the scene, however, so this script could be deprecated

### [LevelSelect](MinimalScripts/LevelSelect.cs)
- No changes necessary that haven't already been suggested for all scripts; this is on each individual button to handle level selections

### [LevelSelectButtons](MinimalScripts/LevelSelectButtons.cs)
- No changes necessary that haven't already been suggested for all scripts; this basically disables buttons for levels that haven't been designed yet and would become deprecated when all levels are finished

### [LightingOptimizer](MinimalScripts/LightingOptimizer.cs)
- No changes necessary that haven't already been suggested for all scripts; this acts in a similar way for LampLightsOff but for interior lighting

### [ShotParticleDestroyer](MinimalScripts/ShotParticleDestroyer.cs)
- Use a conditional timer instead of a coroutine.

### [StoreAnimationBkgd](MinimalScripts/StoreAnimationBkgd.cs)
- Probably could be made deprecated by changes in the scene

### [StoreButton](MinimalScripts/StoreButton.cs)
- No changes necessary that haven't already been suggested for all scripts

### [StoreStatus](MinimalScripts/StoreStatus.cs)
- Could be made redundant with the suggested StoreManager changes; all this does is use conditionals to determine what text to show for upgrade costs (would instead be updating the UI text using StoreManager by accessing the arrays suggested for StoreManager)