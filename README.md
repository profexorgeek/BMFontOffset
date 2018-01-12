# BMFontOffset
BMFontOffset makes it easier to add X and Y offsets to bitmapped font files so multiple fonts can live on a single sprite sheet. This improves game performance by enabling the loading of multiple fonts from a single texture.

# How to use
- Create your fonts with Angelcode's Bitmap Font Creator tool.
- Use Photoshop or a similar program to pull the created pngs into your spritesheet
- Find the X and Y offset of the font in your spritesheet (distance from top left corner)
- Build and run this tool, use command line arguments to specify the offsets, src and dest files
- Change the texture name in the fnt file to point to your spritesheet
- Use the final fnt and spritesheet in your game, fonts will be loaded from the spritesheet!
