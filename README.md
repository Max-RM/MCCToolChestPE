EN

MCCToolChestPE is one of the most powerful tools ever created for editing various Minecraft Bedrock world's NBT data and performing world conversions (BE > JE). It was created by and fully belongs to CynodontA (A Cynodont) many years ago:
https://twitter.com/cynodonta

Around the beginning of the COVID-19 pandemic, during the summer–autumn of 2020, the developer disappeared from all known social media accounts in 2020 and has not been seen online since. As a result, the project appears to have been abandoned.

Following this, development of MCCToolChestPE was effectively halted. New Minecraft Bedrock Edition world versions continued to be supported up to version 1.16.40.02 (in reality, support continued mostly by inertia). With version 1.16.100.04, chunk-related issues already began to appear, and all subsequent game updates became largely unsupported by the tool, with the exception of editing level.dat and ~local_player data. This happened because Mojang significantly changed the chunk format and continued to make major changes to it afterward.

Thus began the dark age of NBT editors. For years afterward, neither Windows nor Android received a new high-quality editor until Amulet Map Editor appeared alongside its specialized third-party plugins.

Nevertheless, some users still prefer a simple and familiar tree-view editor over a full 3D world editor when modifying certain data. As of 2026, several projects have unexpectedly appeared and then faded away, including "Bedrock Toolchest." The unofficial leader remains "Universal Minecraft Tool" developed by MattG (oPryzeLP), which supports modern game versions, although it is a paid commercial product.

And now, to the present day (14.06.2026).

I discovered that MCCToolChestPE can be almost completely decompiled back into a functional and compilable source code state using a combination of ILSpy for decompilation (because this is NET C# proggram) and Cursor AI for code refinement, gradually polishing the code until it compiled into a fully working application.
---
The "Original" folder will contain the original reconstructed codebase. It will receive only occasional updates intended to fix existing issues. Please excuse the messy code and even the presence of some already-compiled files inside the repository. In any case, there is no reason for concern, as the repository contains all files and source code required to build the project.

The "Modified" folder will contain a modified version rather than the original one, as many potential improvements have accumulated over the years:

1. The primary goal is support for modern world formats, which is currently absent.
2. There is a well-known issue with the world map viewer: if your world is too large, the application becomes extremely slow and may take a very long time to process and generate the world map. It appears that the application attempts to render the entire world map at once instead of generating it incrementally, which could prevent freezes lasting tens of minutes and reduce excessive RAM usage.
3. The existing map art tool is not sufficiently optimized and lacks some useful functionality. It could potentially be improved to reach a feature set similar to Tryashtar's Image Map.
4. Data stored under LevelDB keys such as "structuretemplate_..." or "structuretemplate_mystructure:..." is not displayed in the data list and does not have a dedicated category. These entries contain structures saved within the world and created using Structure Blocks.
5. Bedrock Edition worlds containing more than three dimensions trigger an "out of range..." error when opened in MCCToolChestPE and therefore cannot be edited. This primarily affects worlds created in leaked NetEase development builds, as those versions allow the use of the "/changedimension" command to travel to dimensions with an index greater than 2 (Overworld = 0, Nether = 1, The End = 2). All additional dimensions use Overworld-style terrain generation unless special add-ons are used to modify it. This issue should be fixed.
6. The possibility of porting the application to other operating systems could also be considered, including macOS (x64/ARM64), Linux (x64/x86/ARM64/ARM32/etc.), and other platforms.
At the moment, I have already managed to compile Windows ARM64 exe and even Windows ARM32 exe for the leaked and only existing 32-bit ARM version of Windows - Windows 10 ARM32 15035, which is known as a semi-dead platform, which is very difficult to port something new to, but nevertheless it turned out and it's impressive.
This is not a complete or exhaustive list. It only contains the issues, limitations, and improvement opportunities that I have personally discovered and believe should be addressed.

I will most likely not take on item #1 myself, even though many people would consider it the most important feature. I personally have not updated beyond version 1.16.40.02, and newer versions of Minecraft Bedrock Edition do not particularly interest me. Supporting modern world formats is an extremely difficult task, and I have little desire to focus on it.
However, you are free to take the code available here, create your own fork, and implement any changes you wish, including support for all newer game versions (1.26.X.X and beyond).
The only condition is that CynodontA (A Cynodont) MUST ALWAYS BE CREDITED as the sole original owner and creator of MCCToolChestPE. This acknowledgment is required as a tribute to a great developer who is no longer with us and who was one of the very few people in the world to create a fully featured NBT editor for Minecraft Bedrock Edition.

In addition, attribution to MaxRM, owner of TNT ENTERTAINMENT Inc organization, is mandatory, as it is through efforts that this source code is available at all. I understand that, over the course of these six years, anyone could theoretically have done the same thing. Nevertheless, the community showed little interest in preserving and advancing NBT editors for Minecraft Bedrock Edition, and as a result, this work was ultimately carried out by me alone. Because of that, I believe it is only fair that this contribution be acknowledged. I consider it unacceptable when people use leaked or recovered source code without even knowing who made it possible for them to modify, maintain, and continue developing the software that they love in the first place.


RU

MCCToolChestPE это один из мощнейших инструментов для редактирования различных NBT данных миров Minecraft Bedrock и конвертации созданный и полностью принадлежащий CynodontA (A Cynodont) https://twitter.com/cynodonta много лет назад.

Примерно в начале эпидемии ковида, летом-осенью 2020 года разработчик пропал из всех соц сетей и не подавал признаков ни в одной из своих соц.сетей, поэтому предполагается, что он умер.

После этого разработка MCCToolChestPE очевидно была приостановлена. Последующие версии миров Minecraft Bedrock Edition поддерживались вплоть до версии 1.16.40.02 (На самом деле поддержка была по инерции), в 1.16.100.04 уже начались проблемы с чанками, а все дальнейшие обновление игры уже практически не поддерживались инструментом за исключением редактирования level.dat и ~local_player из-за того, что Mojang сильно изменила формат чанков и в дальнейшем продолжала сильно его менять.
Так началась тёмная эра для NBT редакторов, после чего ни на Windows, ни на Android не было нового хорошего редактора, пока не появился Amulet Map Editor с специальными плагинами.
И всё же кому-то больше удобно не 3Д редактор мира, а простой привычный Tree view для редактирования некоторых данных. На момент 2026 года внезапно появились и угасли несколько проектов включая "Bedrock Toolchest", негласным лидером на рынке по-прежнему остаётся "Universal Minecraft Tool" От MattG oPryzeLP с поддержкой новых версий игры, но инструмент является платным.

Итак наше время.
Мною было обнаружено, что MCCToolChestPE можно почти полностью декомпилировать до состояния рабочего и компилируемого исходного кода используя связку ILSpy для декомпиляции и Cursor AI для полировки кода, пока он не стал компилироваться в полностью рабочее приложение.
---
В папке Original будет опубликован оригинальный код, который будет редко обновляться, только чтобы убрать текущие существующие ошибки. И простите за грязный код и даже отдельные уже скомпилированные файлы внутри (в любом случае бояться не стоит, так как репозиторий в любом случае содержит всё нужные файлы и весь код для компиляции)
В одной папке Modified будет находится код, который будет уже не оригинальной версией, а модифицированной версией, так как за это время накопилось множество вещей которые можно было бы улучшить.
1. Основное - поддержка современных миров, которой сейчас нет.
2. Затем есть известная проблема с просмотром карты мира - если ваш мир слишком большой, то программа будет сильно лагать и чрезвычайно долго обрабатывать его, формируя карту мира. По видимому это происходит из-за того, что приложение пытается создать карту всего мира сразу, вместо того, чтобы делать это постепенно тем самым избегая зависания намертво на десятки минут и большое использование ОЗУ.
3. Существующий инструмент работы с картами (map arts) недостаточно хороший и так-же имеет проблемы с оптимизацией. Функционал можно довести до аналогичного как в Image Map от Tryashtar.
4. Данные по LDB ключу "structuretemplate_..." или "structuretemplate_mystructure:..." не отображаются в списке данных и не имеют отдельного списка в целом. Это данные хранящие ваши структуры сохранённые в мире и созданные с помощью структурных блоков.

Вероятно я не стану браться за пункт 1, не смотря на то, что многие сочтут его самым важным, поскольку я не обновляюсь с версии 1.16.40.02, лично меня не сильно интересуют новые версии игры Minecraft Bedrock. Это чрезвычайно сложная задача и поэтому я не горю желанием заниматься именно этим пунктом.
Однако. Вы можете лично взять имеющийся здесь код, создать свой форк и сделать такие изменения которые вы хотите, включая поддержку всех новых версий (1.26.X.X и выше), единственным условием является указание CynodontA (A Cynodont) как единственного владельца прав на код MCCToolChestPE, это упоминание требуется как дань уважение великому и ныне покинувшему нас автора и одному из немногих в мире человеку создавшему полноценный NBT редактор для Bedrock Edition. И так-же обязательно требуется указание MaxRM, владельца организации TNT ENTERTAINMENT inc, как того благодаря кому у вас в целом есть этот код. Я понимаю, что за эти долгие 6 лет кто угодно мог бы сделать то же самое, но тем не менее комьюнити было слишком наплевать на NBT редакторы для MCBE и поэтому это было сделано только мною и поэтому вы вынуждены с этим считаться, я считаю недопустимой практику когда люди пользуются слитыми в сеть исходными кодами программ, при этом не зная того благодаря кому они в целом могут менять и обновлять программу так как им хочется.