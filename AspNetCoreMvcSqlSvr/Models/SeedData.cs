using AspNetCoreMvcSqlSvr.Data;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcSqlSvr.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcShohinContext(serviceProvider.GetRequiredService<DbContextOptions<MvcShohinContext>>()))
            {
                if (context.Shohin.Any())
                {
                    return; //すでにデータが存在するなら追加しない。
                }

                context.Shohin.AddRange(
                    new Shohin
                    {
                        ShohinCode = 5600,
                        ShohinName = "せとうちレモン",
                        EditDate = 20211008,
                        EditTime = 203145,
                        Note = "瀬戸内レモンです"
                    },

                    new Shohin
                    {
                        ShohinCode = 6360,
                        ShohinName = "リンゴジュース",
                        EditDate = 20211206,
                        EditTime = 102533,
                        Note = "果汁100%の炭酸飲料です"
                    },

                    new Shohin
                    {
                        ShohinCode = 2580,
                        ShohinName = "カフェオレ",
                        EditDate = 20220321,
                        EditTime = 91106,
                        Note = "200ml増量中",
                    },

                    new Shohin
                    {
                        ShohinCode = 250,
                        ShohinName = "さけおにぎり",
                        EditDate = 20220416,
                        EditTime = 151615,
                        Note = "北海道産さけ使用"
                    },

                    new Shohin
                    {
                        ShohinCode = 260,
                        ShohinName = "うめおにぎり",
                        EditDate = 20220513,
                        EditTime = 111506,
                        Note = "none"
                    },

                    new Shohin
                    {
                        ShohinCode = 8300,
                        ShohinName = "カニクリームコロッケ",
                        EditDate = 20220529,
                        EditTime = 141521,
                        Note = "３個入りです"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}