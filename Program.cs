using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Threading;

namespace NinjaSagaTP
{

	public enum Gender { Male, Female }
	public enum BloodlineOrigin { Uchiha, Hyuga, Uzumaki, Hashirama }

	public struct Character
	{
		public string Name;
		public Gender Gender;
		public BloodlineOrigin Bloodline;

	}

	public interface ICharacterAppearance
	{
		void setBodyType();
		void setSkinTone();
		void setHairStyle();
		void setHairColor();
		void setFaceShape();
		void setEyebrows();
		void setEyeShape();
		void setEyeColor();
		void setFacialHair();
		void setTopAttire();
		void setTopAttireColor();
		void setBottomAttire();
		void setBottomAttireColor();
		void setFootwear();
		void setFootwearColor();
		void setHeaddress();
		void setFacewear();

	} //creating an interface for character appearance to be implemented on character design class

	public struct STATS
	{
		public byte strength;
		public byte intelligence;
		public byte agility;
		public byte vitality;
	}

	public abstract class CharacterGameplay
	{
		public abstract void setBloodLine();
		public abstract void setElement();
		public abstract void setVillage();
		public abstract void setWeapon();
		public abstract void setHitParticleColor();
		public abstract void setCharacterAuraColor();




	} //abstract class so that that class who will inherit it will know what to implement on their class, it contains mostly features of the character related to the gameplay. It is made abstract becuase it is a class that shouldn't be instantiated rather just inherited

	public class characterOrigin
	{
		public virtual void characterStory(string theUsersName)
		{
			string story = $"\nIn a secluded village nestled deep within the mountains, there lived a young orphan named {theUsersName}. Abandoned at birth, he was taken in by the village elders, who noticed something special about him—the mysterious red markings on his body, a rare and ancient seal believed to harbor immense power.\n\nDespite the villagers' kindness, {theUsersName} grew up feeling like an outsider due to his unique markings. Determined to prove himself, he dedicated his days to mastering martial arts and ancient techniques, seeking to understand the true potential behind the seal.\n\nOne fateful night, a dark force attacked the village, aiming to steal the ancient seal for its malevolent purposes. Unleashing his hidden powers, {theUsersName} defended his home with an extraordinary display of strength, surprising even himself with the extent of his abilities.\n\nRecognized as a hero by the village, {theUsersName} embarks on a journey to uncover the origins and meaning behind his mysterious seal. Along the way, {theUsersName} hones his skills, encounters allies and adversaries, and ultimately embraces his destiny as a protector of balance and harmony in a world of turmoil.";

			typingEffect(story);

		}

		public void typingEffect(string text)
		{
			foreach (char Character in text)
			{
				Console.Write(Character);
				Thread.Sleep(20);
			}


		}
	} // creating a case class for the story of the character

	public class Hero : characterOrigin
	{


	} //inheriting the characteOrigin class but no changes made

	public class Villain : characterOrigin
	{
		public override void characterStory(string theUsersName)
		{
			string story = $"\nIn a remote village shrouded by dense forests, there dwelled a solitary figure named {theUsersName}. Abandoned and ostracized by the village due to his strange and dark chakra, {theUsersName} grew up resentful and isolated. His chakra, an anomaly, granted him immense power but also instilled fear in those around him.\n\nDesperate for acceptance, {theUsersName} sought guidance from forbidden scrolls, delving into dark arts that promised control and dominance. The pursuit of power consumed {theUsersName}, twisting {theUsersName}'s once-good intentions into a thirst for supremacy.\n\nFueled by bitterness and a desire for revenge against those who shunned {theUsersName}, {theUsersName} unleashed chaos upon the village, vowing to claim what he believed was rightfully his—control over the village and its inhabitants. {theUsersName}'s path, once veiled in shadows, now stood as a stark reminder of the consequences of unchecked ambition and the corrupting influence of power.";

			typingEffect(story);
		}

	} //inheriting the characterOrigin class but overriding its method for the villain role story. Changing its introduction based on the user's chosen role.


	public class Shinobi : CharacterGameplay, ICharacterAppearance
	{
		private string name;
		private Gender gender;
		private BloodlineOrigin bloodline;
		private string element;
		private string village;
		private string weaponType;
		private string build;
		private string skinTone;
		private string hairStyle;
		private string hairColor;
		private string faceShape;
		private string eyebrows;
		private string eyeShape;
		private string eyeColor;
		private string facialHair;
		private string Top;
		private string TopColor;
		private string Bottom;
		private string BottomColor;
		private string shoes;
		private string shoeColor;
		private string headdress;
		private string facewear;
		private string characterAuraColor;
		private string hitParticleColor;
		private STATS stats;
		private bool isVillain;
		private string role;

		public Shinobi(string name)
		{
			this.name = name;
		}

		public string getName()
		{
			return name;
		}

		public void setGender()
		{


			while (true)
			{
				Console.Write("\nSelect your gender");
				Console.Write("\n1. Male\n2. Female\n>>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					if (choice == 1)
					{
						gender = Gender.Male;
						break;
					}
					else if (choice == 2)
					{
						gender = Gender.Female;
						break;
					}
					else
					{
						throw new ArgumentOutOfRangeException();
					}


				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 2.\n");
					//setGender();
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");
					//setGender();
				}
			}
		}//setGender

		public string getGender()
		{
			return gender.ToString();
		}


		public void setBodyType()
		{

			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your body type");
				Console.WriteLine("1. Slim");
				Console.WriteLine("2. Tone");
				Console.WriteLine("3. Muscular");
				Console.WriteLine("4. Stocky");
				Console.WriteLine("5. Large");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							build = "Slim";
							isValidChoice = true;
							break;
						case 2:
							build = "Tone";
							isValidChoice = true;
							break;
						case 3:
							build = "Muscular";
							isValidChoice = true;
							break;
						case 4:
							build = "Stocky";
							isValidChoice = true;
							break;
						case 5:
							build = "Large";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}


				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}

		}
		public string getBodyType()
		{
			return build;
		}

		public void setSkinTone()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your skin tone");
				Console.WriteLine("1. Fair");
				Console.WriteLine("2. Light");
				Console.WriteLine("3. Dark");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							skinTone = "Fair";
							isValidChoice = true;
							break;
						case 2:
							skinTone = "Light";
							isValidChoice = true;
							break;
						case 3:
							skinTone = "Dark";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 3.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}


		}
		public string getSkinTone()
		{
			return skinTone;
		}
		public void setHairStyle()
		{
			bool isValidChoice = false;

			if (getGender() == "Male")
			{
				while (!isValidChoice)
				{

					Console.WriteLine("\nChoose your hairstyle:");
					Console.WriteLine("1. Crew Cut");
					Console.WriteLine("2. Quiff");
					Console.WriteLine("3. Pompadour");
					Console.WriteLine("4. Undercut");
					Console.WriteLine("5. Buzzcut");
					Console.WriteLine("6. Fade");
					Console.WriteLine("7. Man Bun");
					Console.WriteLine("8. Slick Back");
					Console.WriteLine("9. Side Part");
					Console.WriteLine("10. Dreadlocks");
					Console.Write(">>> ");

					try
					{

						byte choice = byte.Parse(Console.ReadLine());


						switch (choice)
						{
							case 1:
								hairStyle = "Crew Cut";
								isValidChoice = true;
								break;
							case 2:
								hairStyle = "Quiff";
								isValidChoice = true;
								break;
							case 3:
								hairStyle = "Pompadour";
								isValidChoice = true;
								break;
							case 4:
								hairStyle = "Undercut";
								isValidChoice = true;
								break;
							case 5:
								hairStyle = "Buzzcut";
								isValidChoice = true;
								break;
							case 6:
								hairStyle = "Fade";
								isValidChoice = true;
								break;
							case 7:
								hairStyle = "Man Bun";
								isValidChoice = true;
								break;
							case 8:
								hairStyle = "Slick Back";
								isValidChoice = true;
								break;
							case 9:
								hairStyle = "Side Part";
								isValidChoice = true;
								break;
							case 10:
								hairStyle = "Dreadlocks";
								isValidChoice = true;
								break;

							default:
								throw new ArgumentOutOfRangeException();
						}

					}
					catch (ArgumentOutOfRangeException)
					{
						Console.WriteLine("Invalid choice. Please select a number between 1 and 20.\n");

					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid input format. Please enter a number.\n");

					}

				}
			}
			else if (getGender() == "Female")
			{

				Console.WriteLine("1. Bob");
				Console.WriteLine("2. Pixie Cut");
				Console.WriteLine("3. Layered Cut");
				Console.WriteLine("4. Long Waves");
				Console.WriteLine("5. Bangs");
				Console.WriteLine("6. Braided");
				Console.WriteLine("7. Top Knot");
				Console.WriteLine("8. Straight and Sleek");
				Console.WriteLine("9. Updo");
				Console.WriteLine("10. Messy Bun");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());


					switch (choice)
					{
						case 1:
							hairStyle = "Bob";
							isValidChoice = true;
							break;
						case 12:
							hairStyle = "Pixie Cut";
							isValidChoice = true;
							break;
						case 13:
							hairStyle = "Layered Cut";
							isValidChoice = true;
							break;
						case 14:
							hairStyle = "Long Waves";
							isValidChoice = true;
							break;
						case 15:
							hairStyle = "Bangs";
							isValidChoice = true;
							break;
						case 16:
							hairStyle = "Braided";
							isValidChoice = true;
							break;
						case 17:
							hairStyle = "Top Knot";
							isValidChoice = true;
							break;
						case 18:
							hairStyle = "Straight and Sleek";
							isValidChoice = true;
							break;
						case 19:
							hairStyle = "Updo";
							isValidChoice = true;
							break;
						case 20:
							hairStyle = "Messy Bun";
							isValidChoice = true;
							break;

						default:
							throw new ArgumentOutOfRangeException();
					}

				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 20.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}

		}
		public string getHairStyle()
		{
			return hairStyle;
		}
		public void setHairColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nChoose your hair color:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Red");
				Console.WriteLine("4. Purple");
				Console.WriteLine("5. Blue");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							hairColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							hairColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							hairColor = "Red";
							isValidChoice = true;
							break;
						case 4:
							hairColor = "Purple";
							isValidChoice = true;
							break;
						case 5:
							hairColor = "Blue";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();

					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");



				}

			}

		}
		public string getHairColor()
		{
			return hairColor;
		}
		public void setFaceShape()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your face type/shape:");
				Console.WriteLine("1. Oval");
				Console.WriteLine("2. Square");
				Console.WriteLine("3. Round");
				Console.WriteLine("4. Oblong");
				Console.WriteLine("5. Heart");
				Console.Write(">>> ");

				try
				{
					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							faceShape = "Oval";
							isValidChoice = true;
							break;
						case 2:
							faceShape = "Square";
							isValidChoice = true;
							break;
						case 3:
							faceShape = "Round";
							isValidChoice = true;
							break;
						case 4:
							faceShape = "Oblong";
							isValidChoice = true;
							break;
						case 5:
							faceShape = "Heart";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}


				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}


		}
		public string getFaceShape()
		{
			return faceShape;
		}
		public void setEyebrows()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your eyebrow style:");
				Console.WriteLine("1. Straight");
				Console.WriteLine("2. Curved");
				Console.WriteLine("3. Soft Arch");
				Console.WriteLine("4. S-Shaped");
				Console.WriteLine("5. Unibrow");
				Console.WriteLine("6. Upward");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							eyebrows = "Straight";
							isValidChoice = true;
							break;
						case 2:
							eyebrows = "Curved";
							isValidChoice = true;
							break;
						case 3:
							eyebrows = "Soft Arch";
							isValidChoice = true;
							break;
						case 4:
							eyebrows = "S-Shaped";
							isValidChoice = true;
							break;
						case 5:
							eyebrows = "Unibrow";
							isValidChoice = true;
							break;
						case 6:
							eyebrows = "Upward";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 6.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}


		}
		public string getEyebrows()
		{
			return eyebrows;
		}
		public void setEyeShape()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your eye shape:");
				Console.WriteLine("1. Upturned");
				Console.WriteLine("2. Round");
				Console.WriteLine("3. Monolid");
				Console.WriteLine("4. Downturned");
				Console.WriteLine("5. Hooded");
				Console.WriteLine("6. Almond");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							eyeShape = "Upturned";
							isValidChoice = true;
							break;
						case 2:
							eyeShape = "Round";
							isValidChoice = true;
							break;
						case 3:
							eyeShape = "Monolid";
							isValidChoice = true;
							break;
						case 4:
							eyeShape = "Downturned";
							isValidChoice = true;
							break;
						case 5:
							eyeShape = "Hooded";
							isValidChoice = true;
							break;
						case 6:
							eyeShape = "Almond";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getEyeShape()
		{
			return eyeShape;
		}
		public void setEyeColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your eye color:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Green");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());


					switch (choice)
					{
						case 1:
							eyeColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							eyeColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							eyeColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							eyeColor = "Green";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getEyeColor()
		{
			return eyeColor;
		}
		public void setFacialHair()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your facial hair style:");
				Console.WriteLine("1. No Facial Hair");
				Console.WriteLine("2. Goatee");
				Console.WriteLine("3. Van Dyke");
				Console.WriteLine("4. Anchor");
				Console.WriteLine("5. Balbo");
				Console.WriteLine("6. Stubble");
				Console.WriteLine("7. Box Beard");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							facialHair = "No Facial Hair";
							isValidChoice = true;
							break;
						case 2:
							facialHair = "Goatee";
							isValidChoice = true;
							break;
						case 3:
							facialHair = "Van Dyke";
							isValidChoice = true;
							break;
						case 4:
							facialHair = "Anchor";
							isValidChoice = true;
							break;
						case 5:
							facialHair = "Balbo";
							isValidChoice = true;
							break;
						case 6:
							facialHair = "Stubble";
							isValidChoice = true;
							break;
						case 7:
							facialHair = "Box Beard";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 7.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getFacialHair()
		{
			return facialHair;
		}
		public void setTopAttire()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your top attire:");
				Console.WriteLine("1. T-shirt");
				Console.WriteLine("2. Long sleeves");
				Console.WriteLine("3. Tank top");
				Console.WriteLine("4. Suit");
				Console.WriteLine("5. Dress");
				Console.WriteLine("6. Robe");
				Console.WriteLine("7. Armor");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							Top = "T-Shirt";
							isValidChoice = true;
							break;
						case 2:
							Top = "Long Sleeves";
							isValidChoice = true;
							break;
						case 3:
							Top = "Tank Top";
							isValidChoice = true;
							break;
						case 4:
							Top = "Suit";
							isValidChoice = true;
							break;
						case 5:
							Top = "Dress";
							isValidChoice = true;
							break;
						case 6:
							Top = "Robe";
							isValidChoice = true;
							break;
						case 7:
							Top = "Armor";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 7.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getTopAttire()
		{
			return Top;
		}
		public void setTopAttireColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect the color of your top:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Red");
				Console.WriteLine("5. Green");
				Console.WriteLine("6. Purple");
				Console.WriteLine("7. White");
				Console.WriteLine("8. Gray");
				Console.WriteLine("9. Pink");
				Console.WriteLine("10. Yellow");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							TopColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							TopColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							TopColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							TopColor = "Red";
							isValidChoice = true;
							break;
						case 5:
							TopColor = "Green";
							isValidChoice = true;
							break;
						case 6:
							TopColor = "Purple";
							isValidChoice = true;
							break;
						case 7:
							TopColor = "White";
							isValidChoice = true;
							break;
						case 8:
							TopColor = "Gray";
							isValidChoice = true;
							break;
						case 9:
							TopColor = "Pink";
							isValidChoice = true;
							break;
						case 10:
							TopColor = "Yellow";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 10.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getTopAttireColor()
		{
			return TopColor;
		}
		public void setBottomAttire()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your bottom attire:");
				Console.WriteLine("1. Slacks");
				Console.WriteLine("2. Jeans");
				Console.WriteLine("3. Skirt");
				Console.WriteLine("4. Shorts");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							Bottom = "Slacks";
							isValidChoice = true;
							break;
						case 2:
							Bottom = "Jeans";
							isValidChoice = true;
							break;
						case 3:
							Bottom = "Skirt";
							isValidChoice = true;
							break;
						case 4:
							Bottom = "Shorts";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getBottomAttire()
		{
			return Bottom;
		}
		public void setBottomAttireColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your character's bottom color:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Red");
				Console.WriteLine("5. Green");
				Console.WriteLine("6. Purple");
				Console.WriteLine("7. White");
				Console.WriteLine("8. Gray");
				Console.WriteLine("9. Pink");
				Console.WriteLine("10. Yellow");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							BottomColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							BottomColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							BottomColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							BottomColor = "Red";
							isValidChoice = true;
							break;
						case 5:
							BottomColor = "Green";
							isValidChoice = true;
							break;
						case 6:
							BottomColor = "Purple";
							isValidChoice = true;
							break;
						case 7:
							BottomColor = "White";
							isValidChoice = true;
							break;
						case 8:
							BottomColor = "Gray";
							isValidChoice = true;
							break;
						case 9:
							BottomColor = "Pink";
							isValidChoice = true;
							break;
						case 10:
							BottomColor = "Yellow";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 10.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getBottomAttireColor()
		{
			return BottomColor;
		}
		public void setFootwear()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your shoes:");
				Console.WriteLine("1. Boots");
				Console.WriteLine("2. Sandals");
				Console.WriteLine("3. Slippers");
				Console.WriteLine("4. Heels");
				Console.WriteLine("5. High-heels");
				Console.WriteLine("6. Rubber Shoes");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							shoes = "Boots";
							isValidChoice = true;
							break;
						case 2:
							shoes = "Sandals";
							isValidChoice = true;
							break;
						case 3:
							shoes = "Slippers";
							isValidChoice = true;
							break;
						case 4:
							shoes = "High Heels";
							isValidChoice = true;
							break;
						case 5:
							shoes = "Heels";
							isValidChoice = true;
							break;
						case 6:
							shoes = "Rubber Shoes";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getFootwear()
		{
			return shoes;
		}
		public void setFootwearColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect the color of your shoes:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Red");
				Console.WriteLine("5. Green");
				Console.WriteLine("6. Purple");
				Console.WriteLine("7. White");
				Console.WriteLine("8. Gray");
				Console.WriteLine("9. Pink");
				Console.WriteLine("10. Yellow");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							shoeColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							shoeColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							shoeColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							shoeColor = "Red";
							isValidChoice = true;
							break;
						case 5:
							shoeColor = "Green";
							isValidChoice = true;
							break;
						case 6:
							shoeColor = "Purple";
							isValidChoice = true;
							break;
						case 7:
							shoeColor = "White";
							isValidChoice = true;
							break;
						case 8:
							shoeColor = "Gray";
							isValidChoice = true;
							break;
						case 9:
							shoeColor = "Pink";
							isValidChoice = true;
							break;
						case 10:
							shoeColor = "Yellow";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 10.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getFootwearColor()
		{
			return shoeColor;
		}
		public void setHeaddress()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your headdress:");
				Console.WriteLine("1. Crown");
				Console.WriteLine("2. Bandana");
				Console.WriteLine("3. Knight Helmet");
				Console.WriteLine("4. Top Hat");
				Console.WriteLine("5. Cowboy Hat");
				Console.WriteLine("6. Hood");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							headdress = "Crown";
							isValidChoice = true;
							break;
						case 2:
							headdress = "Bandana";
							isValidChoice = true;
							break;
						case 3:
							headdress = "Knight Helmet";
							isValidChoice = true;
							break;
						case 4:
							headdress = "Top Hat";
							isValidChoice = true;
							break;
						case 5:
							headdress = "Cowboy Hat";
							isValidChoice = true;
							break;
						case 6:
							headdress = "Hood";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getHeaddress()
		{
			return headdress;
		}
		public void setFacewear()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your facewear:");
				Console.WriteLine("1. Mask");
				Console.WriteLine("2. Sunglasses");
				Console.WriteLine("3. Eyeglasses");
				Console.WriteLine("4. Witch Doctor Mask");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							facewear = "Mask";
							isValidChoice = true;
							break;
						case 2:
							facewear = "Sunglasses";
							isValidChoice = true;
							break;
						case 3:
							facewear = "Eyeglasses";
							isValidChoice = true;
							break;
						case 4:
							facewear = "Witch Doctor Mask";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}
		}
		public string getFacewear()
		{
			return facewear;
		}



		//------------GAMEPLAY------------//
		public override void setBloodLine()
		{
			bool isValidChoice = false;
			while (!isValidChoice)
			{
				Console.WriteLine("\nSelect the Bloodline Origin:");
				Console.WriteLine("1. Uchiha");
				Console.WriteLine("2. Hyuga");
				Console.WriteLine("3. Uzumaki");
				Console.WriteLine("4. Hashirama");
				Console.Write(">>> ");

				try
				{
					byte choice = byte.Parse(Console.ReadLine());


					switch (choice)
					{
						case 1:
							bloodline = BloodlineOrigin.Uchiha;
							isValidChoice = true;
							break;

						case 2:
							bloodline = BloodlineOrigin.Hyuga;
							isValidChoice = true;
							break;

						case 3:
							bloodline = BloodlineOrigin.Uzumaki;
							isValidChoice = true;
							break;

						case 4:
							bloodline = BloodlineOrigin.Hashirama;
							isValidChoice = true;
							break;

						default:
							throw new ArgumentOutOfRangeException();
					}


				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 4.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}


			}



		}//--end of SET BLOODLINE

		public string getBloodline()
		{
			return bloodline.ToString();
		}

		public override void setElement()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{
				Console.WriteLine("\nSelect your character's element release");
				Console.WriteLine("1. Fire");
				Console.WriteLine("2. Water");
				Console.WriteLine("3. Earth");
				Console.WriteLine("4. Lightning");
				Console.WriteLine("5. Wind");
				Console.Write(">>> ");

				try
				{
					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							element = "Fire";
							isValidChoice = true;
							break;
						case 2:
							element = "Water";
							isValidChoice = true;
							break;
						case 3:
							element = "Earth";
							isValidChoice = true;
							break;
						case 4:
							element = "Lightning";
							isValidChoice = true;
							break;
						case 5:
							element = "Wind";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}
			}


		}//set element

		public string getElement()
		{
			return element;
		}

		public override void setVillage()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your village");
				Console.WriteLine("1. Hidden Leaf");
				Console.WriteLine("2. Hidden Mist");
				Console.WriteLine("3. Hidden Cloud");
				Console.WriteLine("4. Hidden Sand");
				Console.WriteLine("5. Hidden Stone");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());


					switch (choice)
					{
						case 1:
							village = "Hidden Leaf";
							isValidChoice = true;
							break;
						case 2:
							village = "Hidden Mist";
							isValidChoice = true;
							break;
						case 3:
							village = "Hidden Cloud";
							isValidChoice = true;
							break;
						case 4:
							village = "Hidden Sand";
							isValidChoice = true;
							break;
						case 5:
							village = "Hidden Stone";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}

				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 5.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}


		}// end of set village

		public string getVillage()
		{
			return village;
		}

		public override void setWeapon()
		{

			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect you weapon type");
				Console.WriteLine("1. Kunai");
				Console.WriteLine("2. Shuriken");
				Console.WriteLine("3. Katana");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							weaponType = "Kunai";
							isValidChoice = true;
							break;
						case 2:
							weaponType = "Shuriken";
							isValidChoice = true;
							break;
						case 3:
							weaponType = "Katana";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();

					}

				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 3.\n");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.\n");

				}

			}

		}// end of set weapon

		public string getWeapon()
		{
			return weaponType;
		}

		public override void setHitParticleColor()
		{
			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect the hit particle color:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Red");
				Console.WriteLine("5. Green");
				Console.WriteLine("6. Purple");
				Console.WriteLine("7. White");
				Console.WriteLine("8. Gray");
				Console.WriteLine("9. Pink");
				Console.WriteLine("10. Yellow");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							hitParticleColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							hitParticleColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							hitParticleColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							hitParticleColor = "Red";
							isValidChoice = true;
							break;
						case 5:
							hitParticleColor = "Green";
							isValidChoice = true;
							break;
						case 6:
							hitParticleColor = "Purple";
							isValidChoice = true;
							break;
						case 7:
							hitParticleColor = "White";
							isValidChoice = true;
							break;
						case 8:
							hitParticleColor = "Gray";
							isValidChoice = true;
							break;
						case 9:
							hitParticleColor = "Pink";
							isValidChoice = true;
							break;
						case 10:
							hitParticleColor = "Yellow";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 10.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}

		}

		public string getHitParticleColor()
		{
			return hitParticleColor;
		}

		public override void setCharacterAuraColor()
		{

			bool isValidChoice = false;

			while (!isValidChoice)
			{

				Console.WriteLine("\nSelect your character's aura color:");
				Console.WriteLine("1. Black");
				Console.WriteLine("2. Brown");
				Console.WriteLine("3. Blue");
				Console.WriteLine("4. Red");
				Console.WriteLine("5. Green");
				Console.WriteLine("6. Purple");
				Console.WriteLine("7. White");
				Console.WriteLine("8. Gray");
				Console.WriteLine("9. Pink");
				Console.WriteLine("10. Yellow");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							characterAuraColor = "Black";
							isValidChoice = true;
							break;
						case 2:
							characterAuraColor = "Brown";
							isValidChoice = true;
							break;
						case 3:
							characterAuraColor = "Blue";
							isValidChoice = true;
							break;
						case 4:
							characterAuraColor = "Red";
							isValidChoice = true;
							break;
						case 5:
							characterAuraColor = "Green";
							isValidChoice = true;
							break;
						case 6:
							characterAuraColor = "Purple";
							isValidChoice = true;
							break;
						case 7:
							characterAuraColor = "White";
							isValidChoice = true;
							break;
						case 8:
							characterAuraColor = "Gray";
							isValidChoice = true;
							break;
						case 9:
							characterAuraColor = "Pink";
							isValidChoice = true;
							break;
						case 10:
							characterAuraColor = "Yellow";
							isValidChoice = true;
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid choice. Please select a number between 1 and 10.");

				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");

				}

			}

		}

		public string getCharacterAuraColor()
		{
			return characterAuraColor;
		}

		public void setSTATS()
		{
			byte remainingPoints = 15;
			byte strength = 0;
			byte intelligence = 0;
			byte agility = 0;
			byte vitality = 0;

			while (true)
			{
				Console.WriteLine("\nRemaining Points: " + remainingPoints);
				Console.Write("How many points would you like to allocate to Strength: ");

				try
				{
					strength = byte.Parse(Console.ReadLine());

					if (strength > remainingPoints || strength < 0)
					{
						throw new ArgumentOutOfRangeException();
					}
					else
					{
						remainingPoints -= strength;
						break;
					}
				}
				catch (ArgumentOutOfRangeException)
				{
					Console.WriteLine("Invalid input. Your remaining points is " + remainingPoints + ".");
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid input format. Please enter a number.");
				}
			}

			if (remainingPoints == 0)
			{
				intelligence = 0;
				agility = 0;
				vitality = 0;
			}
			else
			{
				while (true)
				{
					Console.WriteLine("Remaining Points: " + remainingPoints);
					Console.Write("How many points would you like to allocate to Intelligence: ");

					try
					{
						intelligence = byte.Parse(Console.ReadLine());

						if (intelligence > remainingPoints || intelligence < 0)
						{
							throw new ArgumentOutOfRangeException();
						}
						else
						{
							remainingPoints -= intelligence;
							break;
						}
					}
					catch (ArgumentOutOfRangeException)
					{
						Console.WriteLine("Invalid input. Your remaining points is " + remainingPoints + ".");
					}
					catch (FormatException)
					{
						Console.WriteLine("Invalid input format. Please enter a number.");
					}
				}

				if (remainingPoints == 0)
				{
					agility = 0;
					vitality = 0;
				}
				else
				{

					if (remainingPoints == 0)
					{
						intelligence = 0;
						agility = 0;
						vitality = 0;
					}
					else
					{
						while (true)
						{
							Console.WriteLine("Remaining Points: " + remainingPoints);
							Console.Write("How many points would you like to allocate to Agility: ");

							try
							{
								agility = byte.Parse(Console.ReadLine());

								if (agility > remainingPoints || agility < 0)
								{
									throw new ArgumentOutOfRangeException();
								}
								else
								{
									remainingPoints -= agility;
									break;
								}
							}
							catch (ArgumentOutOfRangeException)
							{
								Console.WriteLine("Invalid input. Your remaining points is " + remainingPoints + ".");
							}
							catch (FormatException)
							{
								Console.WriteLine("Invalid input format. Please enter a number.");
							}
						}

						if (remainingPoints == 0)
						{
							vitality = 0;
						}
						else
						{
							while (true)
							{
								Console.WriteLine("Remaining Points: " + remainingPoints);
								Console.Write("How many points would you like to allocate to Vitality: ");

								try
								{
									vitality = byte.Parse(Console.ReadLine());

									if (vitality > remainingPoints || vitality < 0)
									{
										throw new ArgumentOutOfRangeException();
									}
									else
									{
										remainingPoints -= vitality;
										break;
									}
								}
								catch (ArgumentOutOfRangeException)
								{
									Console.WriteLine("Invalid input. Your remaining points is " + remainingPoints + ".");
								}
								catch (FormatException)
								{
									Console.WriteLine("Invalid input format. Please enter a number.");
								}
							}
						}
					}

				}
			}

			// Assign values to stats structure or object
			stats.strength = strength;
			stats.intelligence = intelligence;
			stats.agility = agility;
			stats.vitality = vitality;
		}
		public byte getStrength()
		{
			return stats.strength;
		}
		public byte getIntelligence()
		{
			return stats.intelligence;
		}
		public byte getAgility()
		{
			return stats.agility;
		}
		public byte getVitality()
		{
			return stats.vitality;
		}
		public void setIsVillain()
		{
			//bool isVillain = false; // Default value

			while (true)
			{
				try
				{
					Console.Write("\nDo you want your character to be a villain? (Y/N): ");
					string input = Console.ReadLine().ToUpper(); // Read the whole string and convert to uppercase

					if (string.IsNullOrEmpty(input) || (input[0] != 'Y' && input[0] != 'N'))
					{
						throw new ArgumentException("Invalid input. Please enter Y or N.");
					}

					isVillain = (input[0] == 'Y');
					break;
				}
				catch (ArgumentException e)
				{
					Console.WriteLine(e.Message);
				}
			}

			if (isVillain)
			{
				this.role = "Villain";
			}
			else
			{
				this.role = "Hero";
			}

			// Use isVillain boolean for further processing or assignment
		}

		public bool getIsVillain()
		{
			return isVillain;
		}

		public void displayDetails()
		{
			Console.WriteLine("Name: " + getName());
			Console.WriteLine("\nCHARACTER APPEARANCE\n");
			Console.WriteLine("Gender: " + getGender());
			Console.WriteLine("Body Type: " + getBodyType());
			Console.WriteLine("Skin tone: " + getSkinTone());
			Console.WriteLine("Hair Style: " + getHairStyle());
			Console.WriteLine("Hair Color: " + getHairColor());
			Console.WriteLine("Face Shape: " + getFaceShape());
			Console.WriteLine("Eyebrows: " + getEyebrows());
			Console.WriteLine("Eye Shape: " + getEyeShape());
			Console.WriteLine("Eye Color: " + getEyeColor());
			Console.WriteLine("Facial Hair: " + getFacialHair());
			Console.WriteLine("Top Attire: " + getTopAttire());
			Console.WriteLine("Top Attire Color: " + getTopAttireColor());
			Console.WriteLine("Bottom Attire: " + getBottomAttire());
			Console.WriteLine("Bottom Attire Color: " + getBottomAttireColor());
			Console.WriteLine("Footwear: " + getFootwear());
			Console.WriteLine("Footwear Color: " + getFootwearColor());
			Console.WriteLine("Headdress: " + getHeaddress());
			Console.WriteLine("Facewear: " + getFacewear());
			Console.WriteLine("\nGAMEPLAY\n");
			Console.WriteLine("Bloodline: " + getBloodline());
			Console.WriteLine("Element: " + getElement());
			Console.WriteLine("Village: " + getVillage());
			Console.WriteLine("Weapon: " + getWeapon());
			Console.WriteLine("Hit Particle Color: " + getHitParticleColor());
			Console.WriteLine("Character Aura Color: " + getCharacterAuraColor());
			Console.WriteLine("\nSTATS\n");
			Console.WriteLine("Strength: " + getStrength());
			Console.WriteLine("Intelligence: " + getIntelligence());
			Console.WriteLine("Agility: " + getAgility());
			Console.WriteLine("Vitality: " + getVitality());

		}

		public string getRole()
		{
			return this.role;
		}




	} //This is the main class to be used where preceding the classes and structs are used or inherited




	internal class Program
	{
		static string itoAyConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\USERS\WOLF\SOURCE\REPOS\NINJASAGATP\NINJAPROFILES.MDF;Integrated Security=True";


		static void Main()
		{

			bool exit = false;

			while (!exit)
			{
				Console.WriteLine("\nChoose an action: ");
				Console.WriteLine("1. Create User");
				Console.WriteLine("2. View Users");
				Console.WriteLine("3. Delete User");
				Console.WriteLine("4. Exit Program");
				Console.Write(">>> ");

				try
				{

					byte choice = byte.Parse(Console.ReadLine());

					switch (choice)
					{
						case 1:
							Console.WriteLine("Create User");
							CreateUser();
							exit = true;
							break;
						case 2:
							Console.WriteLine("View Users");
							ViewUsers();
							exit = true;
							break;
						case 3:
							Console.WriteLine("Delete User");
							DeleteUser();
							exit = true;
							break;
						case 4:
							Console.WriteLine("Exiting Program...");
							Environment.Exit(0);
							break;
						default:
							throw new ArgumentOutOfRangeException();
					}


				}
				catch (ArgumentOutOfRangeException e)
				{
					Console.WriteLine("Invalid choice. Choose only from 1 to 4.");
				}
				catch (ArgumentException e)
				{
					Console.WriteLine("Invalid choice. Please enter only numbers.");
				}
				catch (Exception e)
				{
					Console.WriteLine("Error!: " + e.Message);
				}
			}





			Console.ReadKey();

		}


		//Here are the methods where the users can choose between an action he wants to take and used in the Main class

		public static void CreateUser()
		{


			try
			{
				using (SqlConnection sqlObj = new SqlConnection(itoAyConnectionString))
				{
					sqlObj.Open();
					Console.WriteLine("Connected to database");


					Console.WriteLine("\nPersonal Information: ");
					Console.Write("Enter your name: ");
					string name = Console.ReadLine().Trim();

					if(name.Equals(""))
					{
						throw new Exception("Name cannot be blank or white space!");
					}

					Shinobi myShinobi = new Shinobi(name);
					myShinobi.setGender();

					Console.WriteLine("\nCharacter Apperance ");
					myShinobi.setBodyType();
					myShinobi.setSkinTone();
					myShinobi.setHairStyle();
					myShinobi.setHairColor();	
					myShinobi.setFaceShape();
					myShinobi.setEyebrows();
					myShinobi.setEyeShape();
					myShinobi.setEyeColor();
					myShinobi.setFacialHair();
					myShinobi.setTopAttire();
					myShinobi.setTopAttireColor();
					myShinobi.setBottomAttire();
					myShinobi.setBottomAttireColor();
					myShinobi.setFootwear();
					myShinobi.setFootwearColor();
					myShinobi.setHeaddress();
					myShinobi.setFacewear();

					Console.WriteLine("\nCharacter Gameplay: ");
					myShinobi.setBloodLine();
					myShinobi.setElement();
					myShinobi.setVillage();
					myShinobi.setWeapon();
					myShinobi.setHitParticleColor();
					myShinobi.setCharacterAuraColor();

					Console.WriteLine("\nYou have 15 points to distribute to 4 stats: Strength, Intelligence, Agility, Vitality\n");
					myShinobi.setSTATS();
					myShinobi.setIsVillain();

					/*
*/


					string insertQueryString = "INSERT INTO dbo.ninja_profiles (name, gender, body_type, skin_tone, hair_style, hair_color, face_shape, eyebrows, eye_shape, eye_color, facial_hair, top_attire, top_attire_color, bottom_attire, bottom_attire_color, footwear, footwear_color, headdress, facewear, bloodline, element, village, weapon, hit_particle_color, character_aura_color, strength, intelligence, agility, vitality, is_villain) VALUES(@name, @gender, @body_type, @skin_tone, @hair_style, @hair_color, @face_shape, @eyebrows, @eye_shape, @eye_color, @facial_hair, @top_attire, @top_attire_color, @bottom_attire, @bottom_attire_color, @footwear, @footwear_color, @headdress, @facewear, @bloodline, @element, @village, @weapon, @hit_particle_color, @character_aura_color, @strength, @intelligence, @agility, @vitality, @is_villain)";

					using (SqlCommand cmd = new SqlCommand(insertQueryString, sqlObj))
					{
						cmd.Parameters.AddWithValue("@name", myShinobi.getName());
						cmd.Parameters.AddWithValue("@gender", myShinobi.getGender());
						cmd.Parameters.AddWithValue("@body_type", myShinobi.getBodyType());
						cmd.Parameters.AddWithValue("@skin_tone", myShinobi.getSkinTone());
						cmd.Parameters.AddWithValue("@hair_style", myShinobi.getHairStyle());
						cmd.Parameters.AddWithValue("@hair_color", myShinobi.getHairColor());
						cmd.Parameters.AddWithValue("@face_shape", myShinobi.getFaceShape());
						cmd.Parameters.AddWithValue("@eyebrows", myShinobi.getEyebrows());
						cmd.Parameters.AddWithValue("@eye_shape", myShinobi.getEyeShape());
						cmd.Parameters.AddWithValue("@eye_color", myShinobi.getEyeColor());
						cmd.Parameters.AddWithValue("@facial_hair", myShinobi.getFacialHair());
						cmd.Parameters.AddWithValue("@top_attire", myShinobi.getTopAttire());
						cmd.Parameters.AddWithValue("@top_attire_color", myShinobi.getTopAttireColor());
						cmd.Parameters.AddWithValue("@bottom_attire", myShinobi.getBottomAttire());
						cmd.Parameters.AddWithValue("@bottom_attire_color", myShinobi.getBottomAttireColor());

						cmd.Parameters.AddWithValue("@footwear", myShinobi.getFootwear());
						cmd.Parameters.AddWithValue("@footwear_color", myShinobi.getFootwearColor());
						cmd.Parameters.AddWithValue("@headdress", myShinobi.getHeaddress());
						cmd.Parameters.AddWithValue("@facewear", myShinobi.getFacewear());
						cmd.Parameters.AddWithValue("@bloodline", myShinobi.getBloodline());
						cmd.Parameters.AddWithValue("@element", myShinobi.getElement());
						cmd.Parameters.AddWithValue("@village", myShinobi.getVillage());
						cmd.Parameters.AddWithValue("@weapon", myShinobi.getWeapon());
						cmd.Parameters.AddWithValue("@hit_particle_color", myShinobi.getHitParticleColor());
						cmd.Parameters.AddWithValue("@character_aura_color", myShinobi.getCharacterAuraColor());
						cmd.Parameters.AddWithValue("@strength", myShinobi.getStrength());
						cmd.Parameters.AddWithValue("@intelligence", myShinobi.getIntelligence());
						cmd.Parameters.AddWithValue("@agility", myShinobi.getAgility());
						cmd.Parameters.AddWithValue("@vitality", myShinobi.getVitality());
						cmd.Parameters.AddWithValue("@is_villain", myShinobi.getRole());


						int rowsAffected = cmd.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							Console.WriteLine("Data inserted successfully");
						}
						else
						{
							Console.WriteLine("Insertion failed.");
						}

						if (myShinobi.getRole() == "Hero")
						{
							Hero hero = new Hero();
							hero.characterStory(myShinobi.getName());
						}
						else if (myShinobi.getRole() == "Villain")
						{
							Villain villain = new Villain();
							villain.characterStory(myShinobi.getName());
						}
					}


				}


			}
			catch (Exception e)
			{
				Console.Write(e.Message);
			}



			Main();

		}


		public static void ViewUsers()
		{

			try
			{
				using (SqlConnection sqlObj = new SqlConnection(itoAyConnectionString))
				{
					sqlObj.Open();
					Console.WriteLine("Connected to database");

					string selectQueryString = "SELECT * FROM dbo.ninja_profiles";

					using (SqlCommand cmd = new SqlCommand(selectQueryString, sqlObj))
					{

						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{

								while (reader.Read())
								{
									Console.WriteLine($"Employee ID: {reader["Id"]}");
									Console.WriteLine($"Employee name: {reader["name"]}");
									Console.WriteLine($"Emplyee age: {reader["gender"]}");
									Console.WriteLine($"Emplyee salary: {reader["body_type"]}");
									Console.WriteLine($"Skin tone: {reader["skin_tone"]}");
									Console.WriteLine($"Hair style: {reader["hair_style"]}");
									Console.WriteLine($"Hair color: {reader["hair_color"]}");
									Console.WriteLine($"Face shape: {reader["face_shape"]}");
									Console.WriteLine($"Eyebrows: {reader["eyebrows"]}");
									Console.WriteLine($"Eye shape: {reader["eye_shape"]}");
									Console.WriteLine($"Eye color: {reader["eye_color"]}");
									Console.WriteLine($"Facial hair: {reader["facial_hair"]}");
									Console.WriteLine($"Top attire: {reader["top_attire"]}");
									Console.WriteLine($"Top attire color: {reader["top_attire_color"]}");
									Console.WriteLine($"Bottom attire: {reader["bottom_attire"]}");
									Console.WriteLine($"Bottom attire color: {reader["bottom_attire_color"]}");
									Console.WriteLine($"Footwear: {reader["footwear"]}");
									Console.WriteLine($"Footwear color: {reader["footwear_color"]}");
									Console.WriteLine($"Headdress: {reader["headdress"]}");
									Console.WriteLine($"Facewear: {reader["facewear"]}");
									Console.WriteLine($"Bloodline: {reader["bloodline"]}");
									Console.WriteLine($"Element: {reader["element"]}");
									Console.WriteLine($"Village: {reader["village"]}");
									Console.WriteLine($"Weapon: {reader["weapon"]}");
									Console.WriteLine($"Hit particle color: {reader["hit_particle_color"]}");
									Console.WriteLine($"Character aura color: {reader["character_aura_color"]}");
									Console.WriteLine($"Strength: {reader["strength"]}");
									Console.WriteLine($"Intelligence: {reader["intelligence"]}");
									Console.WriteLine($"Agility: {reader["agility"]}");
									Console.WriteLine($"Vitality: {reader["vitality"]}");
									Console.WriteLine($"Role: {reader["is_villain"]}\n");



								}

							}
							else
							{
								Console.WriteLine("No data found");
							}

						}

					}


				}




			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			Main();

		}

		public static void DeleteUser()
		{

			try
			{

				using (SqlConnection sqlObj = new SqlConnection(itoAyConnectionString))
				{
					sqlObj.Open();
					Console.WriteLine("Connected to dabase.");



					//view users Copy start
					try
					{
						using (SqlConnection sqlObj1 = new SqlConnection(itoAyConnectionString))
						{
							sqlObj1.Open();
							Console.WriteLine("Connected to database");

							string selectQueryString = "SELECT * FROM dbo.ninja_profiles";

							using (SqlCommand cmd = new SqlCommand(selectQueryString, sqlObj1))
							{

								using (SqlDataReader reader = cmd.ExecuteReader())
								{

									if (reader.HasRows)
									{

										while (reader.Read())
										{
											Console.WriteLine($"Employee ID: {reader["Id"]}");
											Console.WriteLine($"Employee name: {reader["name"]}");
											Console.WriteLine($"Emplyee age: {reader["gender"]}");
											Console.WriteLine($"Emplyee salary: {reader["body_type"]}");
											Console.WriteLine($"Skin tone: {reader["skin_tone"]}");
											Console.WriteLine($"Hair style: {reader["hair_style"]}");
											Console.WriteLine($"Hair color: {reader["hair_color"]}");
											Console.WriteLine($"Face shape: {reader["face_shape"]}");
											Console.WriteLine($"Eyebrows: {reader["eyebrows"]}");
											Console.WriteLine($"Eye shape: {reader["eye_shape"]}");
											Console.WriteLine($"Eye color: {reader["eye_color"]}");
											Console.WriteLine($"Facial hair: {reader["facial_hair"]}");
											Console.WriteLine($"Top attire: {reader["top_attire"]}");
											Console.WriteLine($"Top attire color: {reader["top_attire_color"]}");
											Console.WriteLine($"Bottom attire: {reader["bottom_attire"]}");
											Console.WriteLine($"Bottom attire color: {reader["bottom_attire_color"]}");
											Console.WriteLine($"Footwear: {reader["footwear"]}");
											Console.WriteLine($"Footwear color: {reader["footwear_color"]}");
											Console.WriteLine($"Headdress: {reader["headdress"]}");
											Console.WriteLine($"Facewear: {reader["facewear"]}");
											Console.WriteLine($"Bloodline: {reader["bloodline"]}");
											Console.WriteLine($"Element: {reader["element"]}");
											Console.WriteLine($"Village: {reader["village"]}");
											Console.WriteLine($"Weapon: {reader["weapon"]}");
											Console.WriteLine($"Hit particle color: {reader["hit_particle_color"]}");
											Console.WriteLine($"Character aura color: {reader["character_aura_color"]}");
											Console.WriteLine($"Strength: {reader["strength"]}");
											Console.WriteLine($"Intelligence: {reader["intelligence"]}");
											Console.WriteLine($"Agility: {reader["agility"]}");
											Console.WriteLine($"Vitality: {reader["vitality"]}");
											Console.WriteLine($"Role: {reader["is_villain"]}\n");



										}

									}
									else
									{
										Console.WriteLine("No data found");
									}

								}

							}


						}




					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
					//view users copy end

					Console.WriteLine("Enter 0 to return to Main Menu");
					Console.Write("Enter user ID to delete: ");





					int employeeIdToDelete;

					

					while (!int.TryParse(Console.ReadLine(), out employeeIdToDelete))
					{

						

						Console.WriteLine("Invalid Input");
						Console.Write("Enter user ID to delete: ");
					}


					if (employeeIdToDelete == 0)
					{
						Main();
					}

					Console.Write("\nAre you sure you want to delete this user? (Y/N): ");
					string input = Console.ReadLine().ToUpper(); // Read the whole string and convert to uppercase

					if (string.IsNullOrEmpty(input) || (input[0] != 'Y' && input[0] != 'N'))
					{
						throw new ArgumentException("Invalid input. Please enter Y or N.");
					}

					if(input == "Y")
					{

						string deleteQuerystring = "DELETE FROM dbo.ninja_profiles WHERE Id = @Id";

						using (SqlCommand cmd = new SqlCommand(deleteQuerystring, sqlObj))
						{
							cmd.Parameters.AddWithValue("Id", employeeIdToDelete);

							int rowsAffected = cmd.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								Console.WriteLine("User deleted successfully");
							}
							else
							{
								Console.Write("No user found with the given ID");
							}

						}


					}
					

					



				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			Main();

		}





	}
}
