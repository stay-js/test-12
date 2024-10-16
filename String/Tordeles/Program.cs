using Tordeles_Lib;

Console.WriteLine(string.Join(", ",
    StringHelper.Split("asd asfasdasd asdasd ewfasf", ' ')));

Console.WriteLine(StringHelper.Trim("\n\t     alma\n"));

Console.WriteLine(StringHelper.WordCount("Elképesztően mennék már gymbe."));


string lorem = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Amet voluptatibus rerum impedit repudiandae earum suscipit rem aspernatur illo excepturi accusantium similique tempora tenetur dolor corporis, ipsum consectetur enim harum ducimus voluptatum eum unde eaque in. Consectetur optio sequi at voluptates, est pariatur recusandae, nesciunt veniam dolore beatae maxime non quasi sapiente eligendi quas fuga nisi facilis repellendus voluptatem. Molestias, consequatur! Maxime nemo ipsum odit excepturi cum vel officiis commodi, officia aut dolorum sit mollitia tempore recusandae harum ratione fugiat blanditiis ut illum delectus ad tenetur repellat! Iste, adipisci deserunt facilis, dignissimos illum illo doloribus ad enim odio perferendis deleniti repudiandae inventore, maiores ipsa pariatur sed dolore a eum accusantium! Fugiat aliquam dolorem veritatis similique error fugit, dolores assumenda tempore reprehenderit nam praesentium rem quas consectetur!";
Console.WriteLine(string.Join("\n", Tordeles.Tordel(lorem, 65)));

Console.WriteLine(string.Join("\n", Tordeles.Tordel("sdfjansjdfhasjbfjsdbhjvgbsdfnioashdklasndljansjdfbsjkdbjksdbfjabsjfbasjbdfasfjkbasjkbfjkasbfkjasbjfbasjbf", 10)));