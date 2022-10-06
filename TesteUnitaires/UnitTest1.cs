using DeWPF;

namespace TesteUnitaires
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDe6()
        {
            De6 de6 = new();
            Assert.AreEqual(de6.NbFaces, 6);

            Face lancer = de6.Lancer();

            Assert.IsTrue(lancer.Valeur >= 1 && lancer.Valeur <= 6);
        }

        [TestMethod]
        public void TestFace()
        {
            Face face = new(4, "4");
            Assert.AreEqual(face.Valeur, 4);
            Assert.AreEqual(face.Nom, "4");
        }

        [TestMethod]
        public void TestLancer()
        {
            De6 de6 = new();
            Lancer lancer = new(de6, de6.Lancer());
            Assert.IsTrue(lancer.Face.Valeur >= 1 && lancer.Face.Valeur <= 6);
        }

        [TestMethod]
        public void TestObjectHasard()
        {
            int faces = 8;
            ObjetHasard obj = new("Test", faces);
            Lancer lancer = new(obj, obj.Lancer());
            Assert.IsTrue(lancer.Face.Valeur >= 1 && lancer.Face.Valeur <= faces);
            Assert.AreEqual(obj.Nom, "Test");
            Assert.AreEqual(obj.NbFaces, faces);
        }

        [TestMethod]
        public void TestPiece()
        {
            Piece piece = new();
            Face face = piece.Lancer();

            Assert.IsTrue(piece.NbFaces == 2);
            Assert.IsTrue(face.Nom == "pile" || face.Nom == "face");
            Assert.AreEqual(face.Valeur, 0);
        }
    }
}