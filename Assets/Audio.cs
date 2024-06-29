using System;
using System.Media;
using System.IO;
using System.Reflection.Metadata;


//classe de abrir o audio em qualquer computador
namespace Assets {
    public class Audio {
        private SoundPlayer soundPlayer;

        //metado de redimincionar o local do diretorio da musica 
        public void MusicaMenu() {
            string fileName = "medieval-75892.wav";
            string executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeFilePath = Path.Combine("Resources", fileName);
            string filePath = Path.Combine(executableDirectory, relativeFilePath);
            string absolutePath = Path.GetFullPath(filePath);

            soundPlayer = new SoundPlayer(absolutePath);
            soundPlayer.PlayLooping();
        }

        //metado para parar a musica
        public void PararMusica() {
            if (soundPlayer != null) {
                soundPlayer.Stop();
            }
        }
    }
}
