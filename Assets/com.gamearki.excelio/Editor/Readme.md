# ExcelIO

## 如何使用
### - 表定义  
第一行: 字段名  
第二行: 字段类型  
第三行起: 数据  

例如:  
```
| name   | job   | atk |
| string | sbyte | int |
| 小陈   | 1     | 2   |
| 老吴   | 2     | 3   |
```

### - 字段类型支持
```
[ √ ] byte
[ √ ] sbyte
[ √ ] ushort
[ √ ] short
[ √ ] uint
[ √ ] int
[ √ ] ulong
[ √ ] long
[ √ ] float
[ √ ] string
[ √ ] bool

byte[]
sbyte[]
ushort[]
short[]
uint[]
int[]
ulong[]
long[]
float[]
string[]
bool[]

Vector2
Vector3
Vector4
Color

Enum<T>
```