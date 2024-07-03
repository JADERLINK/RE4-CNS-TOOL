# RE4-CNS-TOOL
Extract and repack RE4 CNS files (RE4 ubisoft/2007/steam/uhd/Ps2)

**Special thanks:**
<br>*CNS values - Research by AnonymousUser, Zatarita, Mr.Curious, and Mariokart64n*

**Translate from Portuguese Brazil**

Programa destinado a extrair e reempacotar arquivos .CNS
<br> Ao extrair será gerado um arquivo de extenção .idxcns, ele será usado para o repack.

## Extract

Exemplo:
<br>RE4_CNS_TOOL.exe "r404_018.CNS"

! Ira gerar um arquivo de nome "r404_018.idxcns";

## Conteúdo do Arquivo .idxcns

<br>Nota: O conteúdo com // é informativo e não existe no arquivo original.
<br>Nota2: caracteres **# / \\ : !** São usados para comentários.

```
// Arquivo extraído: r404_018.idxcns
# github.com/JADERLINK/RE4-ETM-TOOL
# youtube.com/@JADERLINK
# RE4 CNS TOOL By JADERLINK
# CNS values - Research by AnonymousUser, Zatarita, Mr.Curious, and Mariokart64n

// Defina com 1 para habilitar o campo.
// Defina com 0 para desabilitar o campo.
# [Flags]
ENEMY_FLAG:1
OBJ_FLAG:1
ESP_FLAG:1
ESPGEN_FLAG:0
CTRL_FLAG:0
LIGHT_FLAG:1
PARTS_FLAG:1
MODEL_INFO_FLAG:1
PRIM_FLAG:1
EVT_FLAG:0
SAT_FLAG:1
EAT_FLAG:0

// Defina os limites.
# [Values]
ENEMY_NUM:150
OBJ_NUM:150
ESP_NUM:1300
ESPGEN_NUM:0
CTRL_NUM:0
LIGHT_NUM:50
PARTS_NUM:3300
MODEL_INFO_NUM:500
PRIM_NUM:589824
EVT_NUM:0
SAT_NUM:10
EAT_NUM:0
```

## Repack

Exemplo:
<br>RE4_CNS_TOOL.exe "r404_018.idxcns"

! No arquivo .idxcns vai conter o conteudo que sei colocados no CNS;
<br>! No arquivo .idxcns as linhas iniciadas com um dos caracteres **# / \\ : !** são consideradas comentários;
<br>! O nome do arquivo gerado é o mesmo nome do idxcns, mas com a extenção .CNS;

**At.te: JADERLINK**
<br>2024-07-03