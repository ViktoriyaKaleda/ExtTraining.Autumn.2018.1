# ExtTraining.Autumn.2018.1

1. Для объектов класса Book, у которого есть строковые Title, Author, Year, PublishingHous, Edition, Pages и Price реализовать
возможность строкового представления различного вида. Например, для объекта со значениями
    Title = "C# in Depth", 
    Author = "Jon Skeet", 
    Year = 2019, 
    PublishingHous = "Manning", 
    Edition = 4, 
    Pages = 900, 
    Price = 40$.
могут быть следующие варианты:
 - Book record: Jon Skeet, C# in Depth, 2019, "Manning", 
 - Book record: Jon Skeet, C# in Depth, 2019
 - Book record: Jon Skeet, C# in Depth
 - Book record: C# in Depth, 2019, "Manning"
 - Book record: C# in Depth и т.д.
 
Разработать модульные тесты. (NUnit фреймворк).

2. Не изменяя класс Book, добавить для объектов данного класса дополнительную (любую не существующую у класса изначально) возможность 
форматирования, не предусмотренную классом. 

Разработать модульные тесты. (NUnit фреймворк).

3. Реализовать метод расширения получения из строкового представления целого положительного четырехбайтового числа, записанного в p-ичной 
системе счисления (2<=p<=16), его десятичного значения (при реализации готовые классы-конверторы не использовать!). 

Разработать модульные тесты. (NUnit фреймворк). Примерные тесткейсы.

    "0110111101100001100001010111111" для основания 2 -> 934331071
    "01101111011001100001010111111" для основания 2 -> 233620159
    "11101101111011001100001010" для основания 2 -> 62370570
    "1AeF101" для основания 2 -> ArgumentException
    "11111111111111111111111111111111" для основания 2 -> ArgumentException
    "1AeF101" для основания 16 -> 28242177
    "1ACB67" для основания 16 -> 1756007
    "SA123" для основания 2 -> ArgumentException
    "764241" для основания 8 -> 256161
    "764241" для основания 20 -> ArgumentException
    "10" для основания 5 -> 5
    и т.д.